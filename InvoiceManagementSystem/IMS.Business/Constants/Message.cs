﻿
namespace IMS.Business.Constants
{
    public static class Message
    {
        //Http Messages
        public static string AuthorizationDenied = "Bu sayfayı görüntülemek için yetkiniz yok.";

        //User Messsages
        public static string UserNotFound = "Böyle bir kullanıcı yok.";
        public static string UserAlreadyExist = "Bu kullanıcı zate mevcut.";
        public static string WrongPassword = "Şifre hatalı! Lütfen tekrar deneyiniz.";
        public static string RegistrationSuccessful = "Kayıt Başarılı!";
        public static string RegistrationFailed = "Kayıt Başarısız!";

        //Apartment Messsages
        public static string ApartmentNotFound = "Daire bulunamadı!";
        public static string ApartmentAlreadyExist = "Bu isimde zaten bir daire mevcut.";

        //Apartment Type Messages
        public static string ApartmentTypeAlreadyExist = "Daire tipi zaten mevcut.";
        public static string ApartmentTypeNotFound = "Daire tipi zaten mevcut.";

        //House Type Messages
        public static string HouseNotFound = "Ev bulunamadı!";
        public static string HouseAlreadyExist = "Bu isimde zaten bir ev mevcut.";
        public static string HouseMoreFloors = "Seçtiğiniz apartmanın toplam kat sayısının üstünde kat numarası girdiniz!";

        //Invoice Payment Messages


        //Database Messages
        public static string DatabaseSaveError = "Veri tabanına kaydederken bir hata oluştu!";
        public static string DataDeleted = "Veri silindi.";
        public static string DataUpdated = "Veri güncellendi.";
    }
}
