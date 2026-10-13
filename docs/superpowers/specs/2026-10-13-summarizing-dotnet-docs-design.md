# Skill design: summarizing-dotnet-docs

## Purpose
Condense a .NET/Azure/Entra/Graph documentation page into a short chat summary for a senior PHP + Node.js + Linux developer learning C#/.NET (see `README.md`, 10-day plan). Basics are skipped; concepts are mapped to PHP/Node equivalents.

## Invocation
`/summarizing-dotnet-docs <url> [optional focus]`

Location: `.claude/skills/summarizing-dotnet-docs/SKILL.md` (single file, no scripts). Read-only: fetches and answers in chat; writes nothing to disk and does not edit `README.md`.

## Behavior
1. **Fetch** the URL with WebFetch. Tutorials with numbered steps: summarize the whole page. Long reference pages: summarize only what the focus asks for. Do not follow links unless asked.
2. **Output shape (fixed order):**
   - Introduction: two paragraphs (at most five sentences each) on what the concept is, the problem it solves, and how it works end to end, defining each term on first use
   - Mental model, mapped to the nearest PHP/Node equivalent (say "no direct equivalent" when there is none)
   - Where it differs from what a PHP/Node dev expects (3 bullets)
   - Key code: 1-2 minimal snippets
   - Not covered: topics skipped or outside the focus
3. **Tone:** skip programming basics but explain every .NET/Azure concept the page assumes; about 450 words plus code.

*Revised 2026-10-13 after first use:* the original design looked the URL up in `README.md` and ended with a "for your deliverable" section. The per-page deliverable lines were agent-generated, not part of the plan, so both the lookup and the section were removed; the one-line gist became the fuller introduction.

## Reference content
A small table of recurring equivalents inside SKILL.md (e.g. NuGet ~ npm/Composer; appsettings + User Secrets ~ .env; middleware ~ Express middleware; DI container ~ Laravel service container; `Task` ~ Promise). Not an exhaustive glossary.

## Non-goals
No MCP/Context7 dependency, no notes files, no README updates, no general .NET Q&A.

## Testing
Baseline: run 2-3 pages from Day 5-6 through a subagent without the skill; record failures (length, wrong analogies, missing differences). Write the skill against those failures, re-run, and check output shape and brevity.
