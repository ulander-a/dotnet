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
2. List the page's topics privately; the list is never shown. With a focus, mark each topic in or out and write every section below from the "in" topics alone. With no focus, a tutorial is covered whole and a reference page by its main concepts. The out-of-focus or skipped topics become the closing `Not covered:` line. Do not follow links unless asked.
3. Answer in exactly this shape. Everything comes from the page except PHP/Node analogies; mark anything else as "not on the page".

   ## Overview
   **What:** two or three sentences on what the concept is.
   **Why:** two or three sentences on the problem it solves.
   **How:** two or three sentences on how it works, from start to finish, as one flow.

   ## Technical summary
   **Terminology:** a table with the columns Term, Meaning (ten words or fewer), PHP/Node equivalent. One row per term the page introduces, at most eight rows, most important first. Write "none" in the last column when there is no equivalent.

   **Similar to PHP/Node:** up to three bullets, one sentence each, on what carries over.
   **Different from PHP/Node:** up to three bullets, one sentence each, on what would surprise someone with PHP/Node habits (for C# pages: lifetimes, async, nullability, compile-time vs runtime; for Azure, Entra and Graph pages: auth and consent model, tenancy, secrets and config, tooling and deployment). Rank by surprise and write the top ones.

   **Key code:** one or two minimal snippets, not the full tutorial.

   The answer is these sections and nothing else. Define every term in the Overview in plain words, and put its table row's PHP/Node equivalent in the table, not the Overview. Page details that fit no section are left out; the ranking is never shown. A single line above Overview appears only when the content looks cut off. The `Not covered:` line closes the answer whenever topics were skipped.

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
