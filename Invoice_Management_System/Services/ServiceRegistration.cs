using Application.Interfaces.UnitOfWork;
using Services.Concretes;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Persistence.UnitOfWorks;
using Application.Interfaces.Services;
using System.Text;
using Microsoft.AspNetCore.Http;
using Infrastructure.IdentitySettings.Requirements;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Infrastructure.IdentitySettings;
using Application.Helpers;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Authentication.OAuth;
using System.Security.Claims;
using Persistence.Context;
using Microsoft.AspNetCore.Authentication.Facebook;
using Microsoft.AspNetCore.Authentication.Twitter;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authentication.MicrosoftAccount;

namespace Services
{
    public static class ServiceRegistration
    {
        public static void AddBusinessServices(this IServiceCollection serviceCollection, IConfiguration configuration = null)
        {
            serviceCollection.AddScoped<IClaimsTransformation, ClaimsTransformation>();
            serviceCollection.AddScoped<IAuthorizationHandler, FreeTrialExpireHandler>();
            serviceCollection.AddScoped<IAuthorizationHandler, MinimumAgeHandler>();

            serviceCollection.Configure<EmailSettings>(configuration.GetSection("EmailSettings"));

            serviceCollection.AddScoped<EmailHelper>();
            serviceCollection.AddScoped<TwoFactorAuthenticationService>();


            serviceCollection.AddTransient<IUnitOfWork, UnitOfWork>();

            serviceCollection.AddTransient<IApartmentService, ApartmentManager>();

            serviceCollection.AddTransient<IAuthService, AuthManager>();

            if (true)//proje kapsamında yetkilendirme verir
            {
                serviceCollection.AddMvc(config =>
                {
                    var policy =  new AuthorizationPolicyBuilder()
                                      .RequireAuthenticatedUser()
                                      .Build();

                    config.Filters.Add(new AuthorizeFilter(policy));
                });
            }

            serviceCollection.AddMvc();
            if (false)
            {
                serviceCollection.AddAuthentication(options =>
                {
                    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                }).AddJwtBearer("Admin", options =>
                    {
                        options.TokenValidationParameters = new TokenValidationParameters()
                        {
                            ValidateAudience = true,
                            ValidateIssuer = true,
                            ValidateLifetime = true,
                            ValidateIssuerSigningKey = true,
                            ValidAudience = configuration["Token:Audience"],
                            ValidIssuer = configuration["Token:Issuer"],
                            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Token:SecurityKey"])),
                            ClockSkew = TimeSpan.Zero
                        };

                        options.Events = new JwtBearerEvents
                        {
                            OnTokenValidated = ctx => Task.CompletedTask,
                            OnAuthenticationFailed = ctx => Task.CompletedTask
                        };
                    });
            }

            serviceCollection
                .AddAuthentication()
                .AddExternalLoginOptions(configuration, serviceCollection);//custom method


            serviceCollection.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = new PathString("/Auth/Login");
                options.LogoutPath = new PathString("/Auth/Logout");
                options.AccessDeniedPath = new PathString("/Auth/AccessDenied");
                options.ReturnUrlParameter = CookieAuthenticationDefaults.ReturnUrlParameter;

                options.Cookie = new()
                {
                    Name = "IdentityCookie",
                    HttpOnly = true,
                    SameSite = SameSiteMode.Lax,
                    SecurePolicy = CookieSecurePolicy.Always,
                    IsEssential = true
                };
                options.SlidingExpiration = true;
                options.ExpireTimeSpan = TimeSpan.FromDays(30);
            });

            //serviceCollection.AddMvc().AddRazorPagesOptions(
            //           options =>
            //           {
            //               options.Conventions.AuthorizeFolder("/");
            //               options.Conventions.AuthorizeFolder("/Account/Manage");
            //               options.Conventions.AuthorizeAreaPage("Admin", "/Manage/Accounts");
            //               options.Conventions.AllowAnonymousToPage("/Auth/ResetPassword");
            //           });

            //serviceCollection.AddAuthorization(options =>
            //{
            //    options.AddPolicy("AdminPolicy", policy =>
            //    {
            //        policy.RequireClaim("Admin", OperationClaims.Admin!);
            //    });

            //    options.AddPolicy("UserPolicy", policy =>
            //    {
            //        policy.RequireClaim("User", OperationClaims.User!);
            //    });

            //    options.AddPolicy("AnonymousPolicy", policy =>
            //    {
            //        policy.RequireClaim("Anonymous", OperationClaims.Anonymous!);
            //    });

            //    options.AddPolicy("FreeTrialPolicy", policy =>
            //    {
            //        policy.Requirements.Add(new FreeTrialExpireRequirement());
            //    });

            //    options.AddPolicy("AtLeast18Policy", policy =>
            //    {
            //        policy.AddRequirements(new MinimumAgeRequirement(18));
            //    });
            //});

        }

        public static void AddExternalLoginOptions(this AuthenticationBuilder _authenticationBuilder, IConfiguration configuration, IServiceCollection serviceCollection)
        {
            bool facebookState = false,
                 twitterState = false,
                 googleState = false,
                 microsoftState = false;


            Action<FacebookOptions> facebookOptions = delegate (FacebookOptions options)
            {
                options.AppId = configuration.GetValue<string>("ExternalLoginProviders:Facebook:AppId");
                options.AppSecret = configuration.GetValue<string>("ExternalLoginProviders:Facebook:AppSecret");
                if (!string.IsNullOrEmpty(options.AppId) && !string.IsNullOrEmpty(options.AppSecret))
                {
                    facebookState = true;
                }
                options.CallbackPath = new PathString("/User/FacebookLoginCallback");

                options.Events = new OAuthEvents
                {
                    OnTicketReceived = ctx =>
                    {
                        var db = ctx.HttpContext.RequestServices.GetRequiredService<IMSDbContext>();

                        var claims = new List<Claim>
                         {
                             new Claim(ClaimTypes.Role, "Admin")
                         };
                        var appIdentity = new ClaimsIdentity(claims);
                        ctx.Principal?.AddIdentity(appIdentity);

                        return Task.CompletedTask;
                    },
                };
            };
            Action<TwitterOptions> twitterOptions = delegate (TwitterOptions options)
            {
                options.ConsumerKey = configuration.GetValue<string>("ExternalLoginProviders:Twitter:ConsumerKey");
                options.ConsumerSecret = configuration.GetValue<string>("ExternalLoginProviders:Twitter:ConsumerSecret");
                if (!string.IsNullOrEmpty(options.ConsumerKey) && !string.IsNullOrEmpty(options.ConsumerSecret))
                {
                    twitterState = true;
                }
            };

            Action<GoogleOptions> googleOptions = delegate (GoogleOptions options)
            {
                options.ClientId = configuration.GetValue<string>("ExternalLoginProviders:Google:ClientId");
                options.ClientSecret = configuration.GetValue<string>("ExternalLoginProviders:Google:ClientSecret");
                if (!string.IsNullOrEmpty(options.ClientId) && !string.IsNullOrEmpty(options.ClientSecret))
                {
                    googleState = true;
                }
            };

            Action<MicrosoftAccountOptions> microsoftAccountOptions = delegate (MicrosoftAccountOptions options)
            {
                options.ClientId = configuration.GetValue<string>("ExternalLoginProviders:Microsoft:ClientId");
                options.ClientSecret = configuration.GetValue<string>("ExternalLoginProviders:Microsoft:ClientSecret");
                if (!string.IsNullOrEmpty(options.ClientId) && !string.IsNullOrEmpty(options.ClientSecret))
                {
                    microsoftState = true;
                }
            };

            if (facebookState)
                _authenticationBuilder.AddFacebook(facebookOptions);

            if (twitterState)
                _authenticationBuilder.AddTwitter(twitterOptions);

            if (googleState)
                _authenticationBuilder.AddGoogle(googleOptions);

            if (microsoftState)
                _authenticationBuilder.AddMicrosoftAccount(microsoftAccountOptions);

        }
    }
}
