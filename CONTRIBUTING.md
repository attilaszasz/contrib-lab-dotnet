# Contributing to ContribLab DotNet

Thanks for wanting to contribute! This repository is designed for people who may be opening
their first pull request on GitHub. There are no silly questions, and the maintainers would
rather help you than see you struggle in silence.

## Before you start

- Read the [README](README.md) so you know how to build and run the project.
- Install the [.NET 10 SDK](https://dotnet.microsoft.com/download/dotnet/10.0).
- Make sure `dotnet build` and `dotnet test` succeed on your machine before you change
  anything.

## The contribution workflow

### 1. Choose an open issue

Look at the repository's **Issues** tab. Issues labelled `good first issue` are specifically
sized for a first contribution. Read the issue carefully and ask a question in the issue
comments if anything is unclear.

Do not start working on an issue that is already assigned to somebody else.

### 2. Fork the repository

Click **Fork** in the top-right corner of the GitHub repository page. This creates your own
copy of the repository under your GitHub account.

### 3. Clone your fork

```bash
git clone https://github.com/<your-username>/contrib-lab-dotnet.git
cd contrib-lab-dotnet
```

### 4. Create a new branch

Never make changes directly on `main`. Create a branch with a descriptive name. A good
convention is:

```text
fix/issue-12-contact-validation
```

The example includes the issue number and a short description. Pick a name that matches
your issue.

```bash
git switch -c fix/issue-12-contact-validation
```

### 5. Make a focused change

Change only what is needed to fix the issue you picked. Small, focused pull requests are
much easier to review than large ones that touch many unrelated files.

If you are unsure where the relevant code is, search the repository for the text you see in
the issue (page headings, button labels, and so on).

### 6. Test locally

Run the same checks that GitHub Actions will run:

```bash
dotnet restore
dotnet build
dotnet test
```

All three should succeed. If you fixed a bug, it is a nice touch to add or update a test for
it, but the most important thing is that the existing tests still pass.

### 7. Commit the change

```bash
git add <the files you changed>
git commit -m "Fix contact form validation message"
```

Write a short, clear commit message that describes what changed.

### 8. Push the branch

```bash
git push --set-upstream origin fix/issue-12-contact-validation
```

### 9. Open a pull request

Open a pull request from your branch against the `main` branch of this repository. The pull
request template will guide you. Make sure to:

- link the issue with a line such as `Fixes #12` in the description,
- describe what you changed and how you tested it,
- fill in the checklist.

### 10. Respond to review feedback

A maintainer will review your pull request. They may ask questions or request changes. Push
additional commits to the same branch to update the pull request — you do not need to open a
new one.

Once the review is approved and CI is green, a maintainer will merge your change. It is
normal for review to take a little time.

## Pull request rules

- Every pull request must correspond to and link to an existing open GitHub issue.
- Do not make changes directly on `main`.
- Keep pull requests focused on one issue where practical.
- The project must build successfully before you open the pull request.
- Do not modify the CI/CD configuration (`.github/workflows/`) unless your issue is
  specifically about CI/CD.
- Do not commit secrets, credentials or API keys.

## Continuous integration (CI)

When you open or update a pull request, GitHub Actions automatically:

1. restores the NuGet packages,
2. compiles the application,
3. runs the automated tests.

This is called continuous integration, or CI. You will see the result on your pull request
under **Checks**, or in the **Actions** tab of the repository. If CI fails, click the failing
check, read the failing step, fix the problem, and push again. Please try to get CI green
before requesting a review.

The deployment workflow is separate and only runs after changes are merged into `main`. You
never need to deploy anything yourself, and you should not change the deployment workflow as
part of an unrelated bug fix.

## Code style

- Follow the existing code style and naming conventions.
- Keep the architecture simple — this project is intentionally small.
- Use Bootstrap classes that are already in the project rather than adding new libraries.

## A note about the training bugs

This repository deliberately contains bugs. If you find a problem that does not have an
issue yet, feel free to open an issue describing it, but please do not fix unrelated bugs in
the same pull request.

Thanks again for contributing!
