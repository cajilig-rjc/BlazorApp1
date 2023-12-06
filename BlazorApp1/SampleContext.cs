using BlazorApp1.Models;

namespace BlazorApp1
{
    public class SampleContext
    {
       public static List<LocationModel> Locations = new List<LocationModel>
        {
           
           new LocationModel
           {
               Name ="Loc 1",
               Clients = new List<ClientModel>
               {
                  new ClientModel
                  {
                      Name = "Client 1",
                      Months = new List<MonthModel>
                      {                         
                          new MonthModel
                          {
                              Year = 2023,
                              Month = 1,
                              ExcelFilePath =""
                          }
                      }
                  }
               }
           }
        };
    }
}
