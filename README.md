# ContribLab DotNet — Contoso Corner Shop

A small ASP.NET Core (.NET 10) sample storefront used to practise contributing to an
existing open-source project: finding an issue, creating a branch, opening a pull request,
and responding to code review.

> **Training repository disclaimer:** This repository is an intentionally simplified and
> intentionally buggy demo project created for a GitHub contribution training exercise.
> Some implementation choices and defects are deliberate and should not be treated as
> production best practices. Some pages and interactions behave incorrectly on purpose so
> that contributors have something real to fix.

## What is in the sample site?

Contoso Corner Shop is a fictional product catalog. It has no database and no login system —
all data is hardcoded in small in-memory services so the code stays easy to read.

| Page / endpoint      | What it shows                                                        |
| -------------------- | -------------------------------------------------------------------- |
| `/`                  | Home page with a hero banner and a few featured products             |
| `/Products`          | Product catalog with search, category filter, sorting and pagination |
| `/Products/Details/1`| Details for a single product                                         |
| `/Contact`           | A simple contact form                                                |
| `/Cart`              | A hardcoded shopping cart with a demo remove action                  |
| `/Notifications`     | A notification list (empty by default)                               |
| `/Privacy`           | A placeholder privacy page                                           |
| `/api/products`      | JSON API for listing, reading and creating products                  |
| `/api/cart/items`    | JSON API for adding an item to the cart                              |
| `/api/feedback`      | JSON API for submitting feedback                                     |
| `/api/catalog/sample`| JSON endpoint that calls an external sample catalog API              |

## Requirements

- [.NET 10 SDK](https://dotnet.microsoft.com/download/dotnet/10.0)
- A code editor such as Visual Studio, VS Code or JetBrains Rider
- Git

No database, Docker, Node.js or paid service is required.

## Running locally

```bash
dotnet restore
dotnet run --project src/ContribLab.Web
```

The application prints the URL it is listening on (for example
`https://localhost:7194`). Open that URL in a browser. The Home page should load.

## Running the tests

```bash
dotnet test
```

The test project lives in `tests/ContribLab.Tests` and uses xUnit. The tests cover the
correct, working parts of the sample application. They intentionally do **not** assert the
behaviour of the planted training bugs, so the suite is green on `main` even though the
site contains deliberate defects.

## Repository layout

```text
ContribLab.slnx
src/ContribLab.Web          The ASP.NET Core Razor Pages application
  Controllers               Small JSON API controllers
  Models                    Product, cart, notification and form models
  Pages                     Razor Pages (Home, Products, Contact, Cart, ...)
  Services                  In-memory services that provide the sample data
tests/ContribLab.Tests      xUnit test project
.github/workflows           GitHub Actions CI and deployment workflows
```

## How to contribute

Everyone is welcome, including first-time contributors. Start by reading
[CONTRIBUTING.md](CONTRIBUTING.md), then look for open issues labelled
[`good first issue`](https://github.com/attilaszasz/contrib-lab-dotnet/labels/good%20first%20issue).
Each of those issues describes a small, focused problem that is a good fit for a first pull
request.

Every pull request must link to an existing issue and must be made on a branch other than
`main`. See [CONTRIBUTING.md](CONTRIBUTING.md) for the full step-by-step workflow.

## Continuous integration (CI)

This repository uses **GitHub Actions** for continuous integration. You do not need to know
much about CI to contribute — the short version is that GitHub runs the build and the tests
for you, automatically.

When you open a pull request (or push new commits to it), GitHub will:

1. restore the NuGet packages,
2. compile the solution in Release configuration,
3. run the automated tests.

The configuration lives in [`.github/workflows/ci.yml`](.github/workflows/ci.yml). You can
see the result on your pull request under **Checks**, or in the **Actions** tab of the
repository. If a check fails, click it and read the failing step before asking for review.
CI never deploys anything, so it is always safe to run on a pull request.

Running the same commands locally before you push saves time:

```bash
dotnet restore
dotnet build
dotnet test
```

## Live demo

The `main` branch is automatically deployed to a shared Azure App Service demo environment
by [`.github/workflows/deploy.yml`](.github/workflows/deploy.yml).

> **Live demo URL:** <https://contrib-lab-dotnet-endava1.azurewebsites.net/>

The contribution flow looks like this:

```text
Your branch
   ↓
Pull Request
   ↓
GitHub Actions checks the build and tests
   ↓
Review
   ↓
Merge to main
   ↓
Automatic Azure deployment
```

Changes made on a contributor's branch do **not** immediately appear on the public site.
They appear there only after the pull request has been reviewed and merged into `main`.

Because this project intentionally contains bugs, some pages or interactions on the live
site may behave incorrectly by design. That is expected.

### Deployment setup (maintainers)

Deployment uses OpenID Connect (OIDC), so no long-lived Azure credential is stored in the
repository. The workflow reads the non-secret app name from the repository variable
`AZURE_WEBAPP_NAME` and the authentication values from the repository secrets
`AZURE_CLIENT_ID`, `AZURE_TENANT_ID` and `AZURE_SUBSCRIPTION_ID`. These are already
configured for this repository; if the `AZURE_WEBAPP_NAME` variable is ever removed, the
deployment steps are skipped and only the build and tests run.

The deployment workflow runs only on pushes to `main` (and when triggered manually with
**Run workflow**). Pull requests never deploy.
