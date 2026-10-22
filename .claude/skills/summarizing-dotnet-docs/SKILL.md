---
name: summarizing-dotnet-docs
description: Use when the user gives a link to .NET, C#, ASP.NET Core, EF Core, Azure, Entra ID or Microsoft Graph documentation (learn.microsoft.com or similar) and wants it summarized or explained.
argument-hint: <docs-url> [focus]
---

# Summarizing .NET docs

Reader: senior dev from PHP, Node.js and Linux, new to .NET and Azure. Skip programming basics, but explain every .NET or Azure concept the page assumes.

Input: `$ARGUMENTS` = docs URL, optionally followed by a focus (a section or question). If `$ARGUMENTS` is empty, take the URL and focus from the user's message.

Read-only: never write any file.

## Steps

1. Fetch the URL with WebFetch, prompting it for the full page text with headings in order and every code block verbatim. If WebFetch reports a redirect, fetch the redirect target once. If the fetch fails or the page is empty, say so and stop; never summarize from memory. If the content looks cut off, note that and name the last heading you saw.
2. List the page's topics privately. With a focus, mark each topic in or out and write every section below from the "in" topics alone; the first sentence of What states the focus. With no focus, a tutorial is covered whole and a reference page by its main concepts. The size limits below always apply: for a long tutorial, compress the steps into the How flow instead of lengthening any section. The out-of-focus or skipped topics become the closing `Not covered:` line. Do not follow links unless asked.
3. Answer in exactly this shape. Facts come from the page. You may add short background for concepts the page assumes, and PHP/Node analogies; tag background that is not on the page with "(background)". Keep new terms to a minimum: introduce a term only if the reader needs it to follow the page, define it once in a few words, and prefer a plain-word description over a new name. Never show your working (topic list, rankings).

   ## Overview
   **What:** two or three sentences on what the concept is.
   **Why:** two or three sentences on the problem it solves.
   **How:** two or three sentences on how it works, from start to finish, as one flow.

   ## Technical summary
   **Terminology:** a table with the columns Term, Meaning (ten words or fewer), PHP/Node equivalent. One row per term the page introduces; if there are more than eight, keep the eight most important, most important first. Write "none" in the last column when there is no equivalent.

   **Similar to PHP/Node:** up to three bullets, one sentence each, on what carries over.
   **Different from PHP/Node:** up to three bullets, one sentence each, on what would surprise someone with PHP/Node habits (for C# pages: lifetimes, async, nullability, compile-time vs runtime; for Azure, Entra and Graph pages: auth and consent model, tenancy, secrets and config, tooling and deployment; for other pages, whichever of these categories apply). Rank by surprise and write the top ones.

   **Key code:** one or two minimal snippets, not the full tutorial.

   ## TLDR;
   Literally `## TLDR;`. A recap for someone who has just read the page, as opposed to the Overview, which prepares them for it. One to three sentences, only the absolutely most important concepts, in plain words and the order a developer would use them. It may reuse terms already defined, but adds no new ones and no detail from the table or snippets.

   ## Quiz
   A self-check so the reader can tell whether they understood the page. Three numbered questions, then a `---` divider, then the line `Answers (attempt the questions first):` and three numbered one-sentence answers matching the questions. Each question requires recalling or applying an idea, not recognizing a phrase from the summary: ask "what happens if...", "which would you use for... and why", or "how does this differ from what you would do in PHP/Node". Pick the three ideas the reader most needs to have grasped, with at least one on a "Different from PHP/Node" point. Do not repeat the TLDR; wording, and use no new terms.

   Output only the sections above, in this order, plus two exceptions: a one-line note above Overview when the content looks cut off, and a closing `Not covered: a, b, c` line (comma-separated, at most eight items, no explanations) whenever topics were skipped. Page details that fit no section are left out. In the Overview, use plain words and define a term the first time it appears; put PHP/Node comparisons in the table and the Similar/Different bullets, not the Overview.

## Common equivalents

| .NET | PHP / Node |
|---|---|
| NuGet, `.csproj` | Composer / npm, `composer.json` / `package.json` |
| `appsettings.json` + User Secrets | `.env` / dotenv |
| Middleware pipeline | Express/Koa middleware, Laravel middleware |
| DI container (`IServiceCollection`) | Laravel service container; no Node standard |
| `Task` / `async` | Promise / `async` |
| Minimal API | Express route handlers |
| EF Core (change tracking, unit of work) | Doctrine (closest); Prisma has no change tracking; Eloquent is Active Record, EF Core is not |
| `dotnet ef migrations add` (diffs the model) | `doctrine:migrations:diff` / Prisma migrate; Laravel migrations are hand-written |
| `DefaultAzureCredential` | same class in Node (`@azure/identity`); none in PHP |

Use a row only when it actually fits the page.
