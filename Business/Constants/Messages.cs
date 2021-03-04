using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constants
{
   public static class Messages
    {
        public static string AddedMessages = "Eklendi.";
        public static string DeletedMessages = "Silindi";
        public static string UpdatedMessages = "Güncellendi.";
        public static string NameInvalide = "Geçersiz bir isim girdiniz.";
        public static string CarListed = "Araçlar Listelendi";
        public static string MaintenanceTime = "Sistem Bakımda";
        public static string RentalAddedEroor = "Eklemek İstediğini Araç Kiradan Dönmemiştir.";
        public static string CarDetail = "Araç Detayları";
        public static string CarImageLimitExceded = "5 Resimden fazla ekleyemezsiniz.";
        public static string AuthorizationDenied = "Yetkilendirme Reddedildi";
        public static string PasswordError = "Parola Hatalı.";
        public static string UserNotFound = "Kullanıcı Bulunamadı.";
        public static string UserRegistered = "Kullanıcı Kayıtlı.";
        public static string SuccessfulLogin = "Giriş Başarılı";
        public static string UserAlreadyExists = "Kullanıcı Hatası.";
        public static string AccessTokenCreated = "Access Token Oluşturuldu";
    }
}
