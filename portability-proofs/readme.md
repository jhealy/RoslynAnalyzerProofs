# OVERVIEW

This folder is for proofs to demonstrate the portability analyzer. 
Platform compatibility analyzer - https://docs.microsoft.com/en-us/dotnet/standard/analyzers/platform-compat-analyzer

Targets must be compilable to analyze.

Sample WCF application available - https://github.com/jhealy/RoslynAnalyzerProofs/tree/master/RoslynProofs/EightBallWCF

Other projects can be created using various commmands.  Example are below.

.NETCORE 2.1 MVC :  

` dotnet new mvc -framework netcoreapp2.1`

For more see:

* "dotnet new" tool reference - https://docs.microsoft.com/en-us/dotnet/core/tools/dotnet-new
* "dotnet new" template options - https://docs.microsoft.com/en-us/dotnet/core/tools/dotnet-new-sdk-templates

# DEMO - .NET CORE 2.1 to 5.0 

* Create new .NET Core 2.1 project

` dotnet new mvc -framework netcoreapp2.1`

* Compile and run to test.
* Use portability analyzer to check compat with 5.0. It should be 100%.

[ need screenshots ]

* Introduce a breaking change by adding the a call to platformastractions apis to program.cs:

` System.Diagnostics.Debug.WriteLine(ApplicationEnvironment.ApplicationBasePath.ToString()); `

* Reference in the platformabstractions nuget.  https://docs.microsoft.com/en-us/dotnet/core/compatibility/core-libraries/5.0/platformabstractions-package-removed

* Not all things detected!  Let's explore.
*  Switch target platform  to .NET 5.0
[need screenshot]

* Resolve configuration error by removing razor nuget ref - https://stackoverflow.com/questions/57746667/the-project-web-must-provide-a-value-for-configuration-error-after-migrating
* Run project
* Obsever the Endpoint blowout.
[need screenshot]

* Modify the startup.cs to resolve error.

 ```
         public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddMvc(options => 
            {
                options.EnableEndpointRouting = false;
            });
        }
```

# References

* .NET 5.0 breaking changes - https://docs.microsoft.com/en-us/dotnet/core/compatibility/5.0


