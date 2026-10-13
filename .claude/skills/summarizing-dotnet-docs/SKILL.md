---
name: summarizing-dotnet-docs
description: Use when the user gives a link to .NET, C#, ASP.NET Core, EF Core, Azure, Entra ID or Microsoft Graph documentation (learn.microsoft.com or similar) and wants it summarized or explained.
argument-hint: <docs-url> [focus]
---

# Summarizing .NET docs

Reader: senior dev from PHP, Node.js and Linux, working through the 10-day plan in `README.md`. Skip basics. Terse: aim for 250 words or fewer plus code.

Input: `$ARGUMENTS` = docs URL, optionally followed by a focus (a section or question).

Read-only: never edit `README.md` or write any file.

## Steps

1. Fetch the URL with WebFetch, prompting it for the full page text with headings in order and every code block verbatim. If WebFetch reports a redirect, fetch the redirect target once and use that final URL from here on. If the fetch fails or the page is empty, say so and stop; never summarize from memory. If the fetch was truncated, say which part was not read.
2. Find the URL in `README.md`, comparing host and path only (ignore scheme, locale segment such as `en-us`, query string, `#fragment` and trailing slash). A line with two links shares one day and one tick. If listed, note its day, that day's deliverable, and whether it is ticked. If not listed, say "not in the plan" and omit the deliverable line.
3. List the page's topics. With a focus, mark each topic in or out; every section below is written from the "in" topics alone, and the answer ends with `Not covered: <the "out" topics>`. With no focus, a tutorial is covered whole and a reference page by its main concepts. Do not follow links unless asked.
4. Answer in exactly this order. Everything comes from the page except analogies; mark anything else as "not on the page".

   **Gist:** one line, what the page is for.
   **Mental model:** three sentences: the core concept, its nearest PHP/Node equivalent, and where that equivalent stops fitting. Where no equivalent exists, write "no direct equivalent" and explain from first principles.
   **Differs from PHP/Node:** rank every candidate by how likely it is to surprise someone with PHP/Node habits (for C# pages: lifetimes, async, nullability, compile-time vs runtime; for Azure, Entra and Graph pages: auth and consent model, tenancy, secrets and config, tooling and deployment), then fill these three slots with the top three, one sentence of 20 words or fewer each. If the page supports fewer than three, fill only those slots:
   - <surprise 1>
   - <surprise 2>
   - <surprise 3>
   **Key code:** one or two minimal snippets, not the full tutorial.
   **For your deliverable:** (only when listed in the README) one line on what to take for that day's deliverable and one line on what to skip.

   The answer is these sections and nothing else. Mental model is prose, not bullets. Page details that fit no section are left out. Notes on the fetch (truncation, not in the plan) go in one line above Gist, and the optional `Not covered:` line closes the answer.

## Common equivalents

| .NET | PHP / Node |
|---|---|
| NuGet, `.csproj` | Composer / npm, `composer.json` / `package.json` |
| `appsettings.json` + User Secrets | `.env` / dotenv |
| Middleware pipeline | Express/Koa middleware, Laravel middleware |
| DI container (`IServiceCollection`) | Laravel service container; no Node standard |
| `Task` / `async` | Promise / `async` |
| Minimal API | Express route handlers |
| EF Core | Eloquent / Doctrine / Prisma |
| `dotnet ef migrations` | Laravel migrations / Prisma migrate |
| `DefaultAzureCredential` | same class in Node (`@azure/identity`); none in PHP |

Use a row only when it actually fits the page.
