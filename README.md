# Public mirror of Flawless web repo

It is generated from the monorepo in steps:
1. Monorepo commit to dev triggers GitHub action .github/workflows/azure-static-web-apps-jolly-beach-077f26310.yml to deploy to dev website
2. Monorepo PR merge from dev-> main triggers GitHub action .github/workflows/azure-static-web-apps-proud-dune-0340b7710.yml to deploy to prod website
3. Monorepo commit to main triggers GitHub action .github/workflows/mirror-website-to-public-repo.yml which copies API and other things to public mirror website "FlawlessDevelopmentPublic"


Contains all components and dependencies authored by Flawless Development necessary to support and manage releases of any website developed by Flawless Development.

Structure:
```
<repo root>
├── .github/
│   └── workflows/
│       └── mirror-website-to-public-repo.yml
│
└── FlawlessDevelopment/
    ├── FlawlessAPI/
    │   ├── Endpoints/
    │   └── Properties/
    │
    ├── FlawlessByDesign/
    │   ├── Components/
    │   ├── Pages/
    │   ├── Properties/
    │   └── wwwroot/
    │       ├── css/
    │       ├── fonts/
    │       └── images/
    │
    ├── FlawlessDevelopment.Shared/
    │   ├── Models/
    │   └── Services/
    │ 
    └── FlawlessDevelopment.Web/
         ├── Components/
         ├── Pages/
         ├── Properties/
         └── wwwroot/
             ├── css/
             ├── fonts/
             └── images/
