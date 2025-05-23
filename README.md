# WebsitesMonoRepo
MonoRepo for all Flawless Development supported websites

Contains all components and dependencies authored by Flawless Development necessary to support and manage releases of any website developed by Flawless Development.

Structure:
```
<repo root>
├── .github/
│   └── workflows/
│       ├── FlawlessByDesign.yml
│       ├── FlawlessDevelopment.yml
│       ├── CustomerASite1.yml
│       └── ...
│
├── FlawlessDevelopment/
│   ├── FlawlessAPI/
│   │   ├── Endpoints/
│   │   └── Properties/
│   │
│   ├── FlawlessDevelopment/
│   │   ├── Models/
|   │   └── Services/
│   │ 
│   ├── FlawlessDevelopment.Web/
│   │    ├── Components/
│   │    ├── Pages/
│   │    ├── Properties/
│   │    └── wwwroot/
│   │        ├── css/
│   │        ├── fonts/
│   │        └── images/
│   │   
│   └── FlawlessByDesign/
│       ├── Components/
│       ├── Pages/
│       ├── Properties/
│       └── wwwroot/
│           ├── css/
│           ├── fonts/
│           └── images/
│   
│
├── <customer A>/
│   ├── CustomerAPI/
│   │   ├── Endpoints/
│   │   └── Properties/
│   │
│   ├── <customer site 1>/
│   │   ├── Components/
│   │   ├── Pages/
│   │   ├── Properties/
│   │   └── wwwroot/
│   │       ├── css/
│   │       ├── fonts/
│   │       └── images/

```
