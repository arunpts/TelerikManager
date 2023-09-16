using TelerikManager.Models;

namespace TelerikManager.Interface
{
    public interface IManager
    {
        //GetAllRecord
        List<Manager> GetAllManagerDetails(string SearchText, string SelectedPlace,string SelectedEmail);
       // GETSingleRecord
        Manager GetManagerDetails(int ID);
        //Manager GetManagerDetails(int ID);

        List<Manager> GetPlaceList();
        List<Manager> GetEmailList();
        //Add Record
        Manager AddManagerDetails(Manager ObjManager);

        //Update or Edit Record
        void UpdateManagerDetails(Manager objManager);

        //Delete or Remove
        void DeleteManagerDetails(int ID);
    }
}

