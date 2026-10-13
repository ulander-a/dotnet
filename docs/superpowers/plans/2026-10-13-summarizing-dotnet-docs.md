# summarizing-dotnet-docs Implementation Plan

> **For agentic workers:** REQUIRED SUB-SKILL: Use superpowers:subagent-driven-development (recommended) or superpowers:executing-plans to implement this plan task-by-task. Steps use checkbox (`- [ ]`) syntax for tracking.

**Goal:** A project skill that summarizes a pasted .NET/Azure/Entra/Graph docs URL in chat for a senior PHP/Node dev, positioned against the README's 10-day plan.

**Architecture:** One `SKILL.md` (reference/technique skill, no scripts). It fetches the page with WebFetch, looks the URL up in `README.md` for day/deliverable context, and answers in a fixed output shape. Built RED-GREEN: baseline subagent runs without the skill first, then the skill, then re-runs.

**Tech Stack:** Claude Code skill (markdown + YAML frontmatter), WebFetch, subagents for testing.

**Spec:** `docs/superpowers/specs/2026-10-13-summarizing-dotnet-docs-design.md`

## Global Constraints

- Skill path: `.claude/skills/summarizing-dotnet-docs/SKILL.md` (single file, no scripts).
- Invocation: `/summarizing-dotnet-docs <url> [optional focus]`.
- Read-only: no file writes, no `README.md` edits, no notes files.
- No MCP/Context7 dependency; fetch with WebFetch only.
- Output order is fixed: gist, mental model, differences, key code, deliverable/skip.
- Description starts with "Use when" and describes triggers only (no workflow summary); frontmatter under 1024 chars; SKILL.md body under ~500 words.
- Terse, skip basics; say "no direct equivalent" rather than forcing an analogy.

## Review Focus

- URL not listed in `README.md` -> skill says so and still summarizes (no invented day/deliverable).
- URL already ticked `[x]` -> still summarizes; may note it is marked done.
- Fetch fails or returns a redirect/empty page -> says so, does not summarize from memory.
- Very long reference page with a focus argument -> summarizes only the focus.
- Non-Microsoft docs link (e.g. GitHub repo) -> still follows the shape, no fabricated Learn-specific details.

---

### Task 1: Baseline (RED) - run test pages without the skill

**Files:**
- Create: `C:\Users\Alve\AppData\Local\Temp\claude\C--Users-Alve-Code-dotnet\7a9ee350-c925-490c-bff0-5e234876e14c\scratchpad\baseline.md` (scratchpad; not committed)

**Interfaces:**
- Produces: `baseline.md` listing the three raw outputs and a bullet list of observed failures (length, missing PHP/Node mapping, missing differences, no README awareness, hallucination if fetch failed).

Test URLs (chosen to cover: in-README Day 5, in-README Day 6, not-in-README):
- A: `https://learn.microsoft.com/en-us/ef/core/dbcontext-configuration/`
- B: `https://learn.microsoft.com/en-us/azure/key-vault/general/overview`
- C: `https://learn.microsoft.com/en-us/aspnet/core/fundamentals/http-requests` (not in README)

- [ ] **Step 1: Dispatch three general-purpose subagents in parallel, one per URL**

Prompt for each (identical except URL): `Summarize this documentation page for me: <URL>. I'm a senior PHP + Node developer learning C#/.NET.` Do not mention the skill, README, or desired format.

- [ ] **Step 2: Record outputs and failures**

Write `baseline.md` with each output verbatim (trimmed) and the failures observed against the Global Constraints (output shape, length, PHP/Node mapping, differences section, README awareness).

- [ ] **Step 3: Check the failure exists**

If all three outputs already satisfy the fixed shape without guidance, stop and tell the user the skill adds no value. Otherwise proceed.

### Task 2: Write the skill (GREEN)

**Files:**
- Create: `.claude/skills/summarizing-dotnet-docs/SKILL.md`

**Interfaces:**
- Consumes: failures listed in `baseline.md`.
- Produces: a skill invocable as `/summarizing-dotnet-docs <url> [focus]`; `$ARGUMENTS` carries the URL and optional focus.

- [ ] **Step 1: Write SKILL.md**

```markdown
---
name: summarizing-dotnet-docs
description: Use when the user gives a link to .NET, C#, ASP.NET Core, EF Core, Azure, Entra ID or Microsoft Graph documentation (learn.microsoft.com or similar) and wants it summarized or explained.
argument-hint: <docs-url> [focus]
---

# Summarizing .NET docs

Reader: senior dev from PHP, Node.js and Linux, working through the 10-day plan in `README.md`. Skip basics. Terse.

Input: `$ARGUMENTS` = docs URL, optionally followed by a focus (a section or question).

## Steps

1. Fetch the URL with WebFetch. If the fetch fails or the page is empty, say so and stop; never summarize from memory.
2. Find the URL in `README.md`. If listed, note its day, that day's deliverable, and whether it is ticked. If not listed, say "not in the plan" and omit the deliverable line.
3. Tutorial: cover the whole page. Long reference page: cover only the focus; with no focus, cover the main concepts and say what was left out. Do not follow links unless asked.
4. Answer in exactly this order:

   **Gist:** one line, what the page is for.
   **Mental model:** the core concept, mapped to the nearest PHP/Node equivalent. Where none exists, write "no direct equivalent" and explain from first principles.
   **Differs from PHP/Node:** the traps and surprises, as short bullets.
   **Key code:** one or two minimal snippets, not the full tutorial.
   **For your deliverable:** (only when listed in the README) what to take from this page for that day's deliverable, and what is safe to skip.

## Common equivalents

| .NET | PHP / Node |
|---|---|
| NuGet, `.csproj` | Composer / npm, `composer.json` / `package.json` |
| `appsettings.json` + User Secrets | `.env` / dotenv |
| Middleware pipeline | Express/Koa middleware, Laravel middleware |
| DI container (`IServiceCollection`) | Laravel service container; no Node standard |
| `Task` / `async` | Promise / `async` |
| Minimal API | Express route handlers |
| EF Core | Eloquent / Prisma |
| `dotnet ef migrations` | Laravel migrations / Prisma migrate |
| `DefaultAzureCredential` | none; closest is the cloud SDK's default credential chain |

Use a row only when it actually fits the page.
```

- [ ] **Step 2: Check size**

Run: `wc -w .claude/skills/summarizing-dotnet-docs/SKILL.md`
Expected: under ~500 words of body.

### Task 3: Verify and close loopholes (GREEN/REFACTOR)

**Files:**
- Modify: `.claude/skills/summarizing-dotnet-docs/SKILL.md` (only if tests show gaps)
- Create: `...\scratchpad\with-skill.md` (scratchpad)

**Interfaces:**
- Consumes: `SKILL.md`, test URLs A-C from Task 1.

- [ ] **Step 1: Re-run URLs A, B, C**

Dispatch three general-purpose subagents in parallel. Prompt: `Read C:\Users\Alve\Code\dotnet\.claude\skills\summarizing-dotnet-docs\SKILL.md and follow it with $ARGUMENTS = <URL>.`

- [ ] **Step 2: Check each output against the constraints**

Verify: fixed order; PHP/Node mapping present or "no direct equivalent"; differences section present; A and B show day/deliverable, C says "not in the plan" and has no deliverable line; length clearly shorter than baseline. Record in `with-skill.md`.

- [ ] **Step 3: Run the Review Focus edge cases**

Dispatch with the skill: (a) a bogus URL `https://learn.microsoft.com/en-us/nope-404` -> expect a fetch-failure message and no summary; (b) A with focus `lifetime and DI registration` -> expect only that section covered; (c) `https://github.com/dotnet/eShop` -> expect the shape without invented Learn details; (d) a ticked URL (`https://learn.microsoft.com/en-us/ef/core/`) -> expect a summary that notes it is marked done.

- [ ] **Step 4: Fix gaps**

For each failed expectation, edit SKILL.md with a specific fix (a step or a conditional keyed to an observable predicate, not a nuance clause), then re-run only the failing case until it passes.

- [ ] **Step 5: Real invocation**

Run `/summarizing-dotnet-docs https://learn.microsoft.com/en-us/ef/core/modeling/relationships` in this session and confirm the skill is discovered and `$ARGUMENTS` is substituted.

- [ ] **Step 6: Commit (only if the user asks)**

```bash
git add .claude/skills/summarizing-dotnet-docs/SKILL.md docs/superpowers
git commit -m "Add summarizing-dotnet-docs skill"
```
