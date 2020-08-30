using System.Configuration;

namespace MZ.DataLayerSql
{
    public class CommonUtility
    {
        public static string ConnectionString = ConfigurationManager.AppSettings["connectionString"];
    }

    public static class StoreProcedure
    {
        // Users
        public static string GetUserByUsernamePassword = "sp_user_getuserbyusernamenpassword";

        // Banner
        public static string GetBannerById = "sp_GetBannerDetails";
        public static string InsertBanner = "sp_InsertBanner";
        public static string UpdateBanner = "sp_UpdateBanner";
        public static string GetAllBanners = "sp_GetBanner";
        public static string DeleteBanner = "sp_DeleteBanner";

        // About Us
        public static string GetAboutDetails = "sp_GetAboutUDetails";
        public static string UpdateAbout = "sp_UpdateAboutU";


        // Our Clients Banner
        public static string GetClientBannersDetails = "sp_GetClientBannersDetails";
        public static string UpdateClientsBanner = "sp_UpdateClientsBanner";


        // Clients
        public static string GetAllClients = "sp_GetOurClient";
        public static string GetClientById = "sp_GetOurClientDetails";
        public static string InsertClient = "sp_InsertOurClient";
        public static string UpdateClient = "sp_UpdateOurClient";
        public static string DeleteClient = "sp_DeleteOurClient";

        // Company Setting
        public static string GetCompanySetting = "sp_GetCompanySettingDetails";
        public static string UpdateCompanySettings = "sp_UpdateCompanySetting";

        // Machines
        public static string GetAllMachines = "sp_GetOurMachine";
        public static string GetMachineById = "sp_GetOurMachineDetails";
        public static string InsertMachine = "sp_InsertOurMachine";
        public static string UpdateMachine = "sp_UpdateOurMachine";
        public static string DeleteMachine = "sp_DeleteOurMachine";

        // Services
        public static string GetAllServices = "sp_GetOurService";
        public static string GetServicesById = "sp_GetOurServiceDetails";
        public static string InsertServices = "sp_InsertOurService";
        public static string UpdateServices = "sp_UpdateOurService";
        public static string DeleteService = "sp_DeleteOurService";

        //Products
        public static string GetAllProducts = "sp_GetProduct";
        public static string GetProductsById = "sp_GetProductDetails";
        public static string InsertProducts = "sp_InsertProduct";
        public static string UpdateProducts = "sp_UpdateProduct";
        public static string DeleteProduct = "sp_DeleteProduct";

        // Product Category
        public static string GetAllProductCategory = "sp_GetProductCategory";
        public static string GetProductCategoryById = "sp_GetProductCategoryDetails";
        public static string InsertProductCategory = "sp_InsertProductCategory";
        public static string UpdateProductCategory = "sp_UpdateProductCategory";
        public static string DeleteProductCategory = "sp_DeleteProductCategory";

        // Product SubCategory
        public static string GetAllProductSubCategory = "sp_GetProductSubCategory";
        public static string GetProductSubCategoryById = "sp_GetProductSubCategoryDetails";
        public static string InsertProductSubCategory = "sp_InsertProductSubCategory";
        public static string UpdateProductSubCategory = "sp_UpdateProductSubCategory";
        public static string DeleteProductSubCategory = "sp_DeleteProductSubCategory";
        public static string GetSubCategoryByCategoryId = "sp_GetSubCategoryByCategoryId";

        // Product Gallery
        public static string GetAllProductGallery = "sp_GetProductGallery";
        public static string GetProductGalleryById = "sp_GetProductGalleryDetails";
        public static string InsertProductGallery = "sp_InsertProductGallery";
        public static string UpdateProductGallery = "sp_UpdateProductGallery";
        public static string DeleteProductGallery = "sp_DeleteProductGallery";
        public static string GetAllProductsByCategoryId = "sp_GetProductsByCategoryId";
        public static string GetAllProductsBySubCategoryId = "sp_GetProductsBySubCategoryId";
        public static string GetAllProductGalleriesByProductId = "sp_GetProductGalleriesByProductId";

        // Feedback
        public static string GetAllFeedback = "sp_GetFeedback";
        public static string GetFeedbackById = "sp_GetFeedbackDetails";
        public static string InsertFeedback = "sp_InsertFeedback";
        public static string UpdateFeedback = "sp_UpdateFeedback";
        public static string DeleteFeedback = "sp_DeleteFeedback";

        //ImageGallery
        public static string GetAllImageGallery = "sp_GetImageGallery";
        public static string GetImageGalleryById = "sp_GetImageGalleryDetails";
        public static string InsertImageGallery = "sp_InsertImageGallery";
        public static string UpdateImageGallery = "sp_UpdateImageGallery";
        public static string DeleteImageGallery = "sp_DeleteImageGallery";

        //VideoGallery
        public static string GetAllVideoGallery = "sp_GetVideoGallery";
        public static string GetVideoGalleryById = "sp_GetVideoGalleryDetails";
        public static string InsertVideoGallery = "sp_InsertVideoGallery";
        public static string UpdateVideoGallery = "sp_UpdateVideoGallery";
        public static string DeleteVideoGallery = "sp_DeleteVideoGallery";
    }
}
