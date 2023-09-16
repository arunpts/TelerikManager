using TelerikManager.Models;

namespace TelerikManager.Interface
{
    public interface IManager
    {
        //Get All Records
        List<Manager> GetAllManagerDetails(string SearchText, string SelectedPlace,string SelectedEmail);

        //Get Single Record
        Manager GetManagerDetails(int ID);

        //Get Distinct Places
        List<Manager> GetPlaceList();

        //Get Distinct Emails
        List<Manager> GetEmailList();

        //Add Record
        Manager AddManagerDetails(Manager ObjManager);

        //Update or Edit Record
        void UpdateManagerDetails(Manager objManager);

        //Delete or Remove
        void DeleteManagerDetails(int ID);
    }
}

