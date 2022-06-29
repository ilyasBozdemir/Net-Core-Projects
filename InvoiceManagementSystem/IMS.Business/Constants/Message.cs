
namespace IMS.Business.Constants
{
    public static class Message
    {
        //Http Messages
        public static string AuthorizationDenied = "Bu sayfayı görüntülemek için yetkiniz yok.";

        //User Messsages
        public static string UserNotFound = "Böyle bir kullanıcı yok.";
        public static string RegistrationSuccessful = "Kayıt Başarılı!";
        public static string RegistrationFailed = "Kayıt Başarısız!";

        //Apartment Messsages
        public static string ApartmentNotFound = "Daire bulunamadı!";
        public static string ApartmentAlreadyExist = "Bu isimde zaten bir daire mevcut. Lütfen kontrol ediniz.";

        //


        //Database Messages
        public static string DatabaseSaveError = "Veri tabanına kaydederken bir hata oluştu!";
    }
}
