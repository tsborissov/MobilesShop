namespace MobilesShop.Data
{
    public class DataConstants
    {
        public const int BrandNameMinLength = 2;
        public const int BrandNameMaxLength = 20;

        public const int CameraTypeNameMinLength = 2;
        public const int CameraTypeNameMaxLength = 200;

        public const int ChipsetNameMinLength = 5;
        public const int ChipsetNameMaxLength = 30;
        public const int ChipsetCoresMinValue = 1;
        public const int ChipsetCoresMaxValue = 64;
        public const int ChipsetClockMinValue = 500;
        public const int ChipsetClockMaxValue = 10000;


        public const int DisplayNameMinLength = 2;
        public const int DisplayNameMaxLength = 20;
        public const int DisplayResolutionMinLength = 4;
        public const int DisplayResolutionMaxLength = 10;
        public const string DisplayResolutionPattern = @"^([0-9]{3,4} x [0-9]{3,4})$";
        public const int DisplayProtectionMinLength = 3;
        public const int DisplayProtectionMaxLength = 30;
        public const int DisplaySizeMinValue = 0;
        public const int DisplaySizeMaxValue = 10;

        public const int MobilePhoneModelMinLength = 5;
        public const int MobilePhoneModelMaxLength = 30;
        public const int MobilePhoneImageUrlMaxLength = 2048;
        public const int MobilePhoneDetailsMinLength = 5;
        public const int MobilePhoneDetailsMaxLength = 500;
        public const int MobilePhoneConnectivityMinLength = 2;
        public const int MobilePhoneConnectivityMaxLength = 50;
        public const int MobilePhoneMinYearValue = 2010;
        public const int MobilePhoneMaxYearValue = 2030;
        public const int MobilePhoneWeightMinValue = 0;
        public const int MobilePhoneWeightMaxValue = 2000;
        public const int MobilePhonePriceMinValue = 0;
        public const int MobilePhonePriceMaxValue = 10000;
        public const int MobilePhoneMemoryMinValue = 1;
        public const int MobilePhoneMemoryMaxValue = 8;
        public const int MobilePhoneStorageMinValue = 8;
        public const int MobilePhoneStorageMaxValue = 1024;
        public const int MobilePhoneBatteryMinValue = 500;
        public const int MobilePhoneBatteryMaxValue = 20000;
    }
}
