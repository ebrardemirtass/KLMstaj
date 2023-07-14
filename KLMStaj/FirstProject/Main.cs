using UtilityProject;

int modeNumber;

MainHelper mainHelper = new MainHelper();
AlgorithmHelper algorithmHelper = new AlgorithmHelper();

mainHelper.GetValidNumber(out modeNumber, " Lütfen Çalışma Modu Numarası Giriniz: ");

switch (modeNumber)
{
    case 0:
        algorithmHelper.CustomAlgorithm();
        break;
    case 1:
        mainHelper.GetValidNumber(out int starCount, "Yıldız Basamak Sayısı Giriniz: ");
        Console.Write(algorithmHelper.PrintStars(starCount));
        break;
    case 2:
        algorithmHelper.DivideByThree();
        break;
    case 3:
        algorithmHelper.CompanyMode();
        break;
    default:
        Console.WriteLine("Henüz bu mod geliştirilmemiştir.");
        break;
}
