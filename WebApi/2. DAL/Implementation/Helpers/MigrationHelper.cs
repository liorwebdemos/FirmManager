//using Microsoft.EntityFrameworkCore;
//using WebApi.DAL.Contexts;

//namespace WebApi.DAL.Helpers
//{
//    public static class MigrationHelper
//    {
//        public static WebApplication MigrateDatabase(this WebApplication webApp)
//        {
//            using (var scope = webApp.Services.CreateScope())
//            {
//                using (var appContext = scope.ServiceProvider.GetRequiredService<MainContext>())
//                {
//                    appContext.Database.Migrate();
//                }
//            }
//            return webApp;
//        }
//    }
//}
