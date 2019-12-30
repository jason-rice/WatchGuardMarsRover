using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using WatchGuardMarsRover.Models;

namespace WatchGuardMarsRover.Helper
{
    public class Repository
    {
        MarsRoverApi _api = new MarsRoverApi();

        public async Task<List<DisplayImages>> GetNasaImagesByDate(string dateChosen, List<DisplayImages> displayImagesList)
        {
            try
            {
                MarsRoverImage marsRoverImage = new MarsRoverImage();
                HttpClient client = _api.Initial();
                HttpResponseMessage responseMessage = await client.GetAsync("api/v1/rovers/curiosity/photos?earth_date=" + dateChosen + "&api_key=gVnoxQADOqBDAVopaZlfEhYtL7gNSxrXrQDruJDv");
                if (responseMessage.IsSuccessStatusCode)
                {
                    var resultString = responseMessage.Content.ReadAsStringAsync().Result;
                    marsRoverImage = JsonConvert.DeserializeObject<MarsRoverImage>(resultString);

                    foreach (var item in marsRoverImage.PhotoList)
                    {
                        try
                        {
                            using (WebClient currentClient = new WebClient())
                            {
                                currentClient.DownloadFile(new Uri(item.img_src), Path.GetFullPath("wwwroot/Images/NasaPic" + item.id + ".png"));
                                DisplayImages displayImages = new DisplayImages();
                                displayImages.ImageName = "NasaPic" + item.id + ".png";
                                displayImagesList.Add(displayImages);
                            }
                        }
                        catch
                        {

                        }
                    }
                }
                return displayImagesList;
            }
            catch
            {
                return displayImagesList;
            }
        }

        public async Task<List<DisplayImages>> GetNasaImagesByDateArray(List<DisplayImages> displayImagesList)
        {
            try
            {
                using (StreamReader sr = new StreamReader(Path.GetFullPath("wwwroot/TextFile/dates.txt")))
                {
                    string line = sr.ReadToEnd();
                    string[] dateStringArray = line.Split("\n");

                    foreach (var item in dateStringArray)
                    {
                        try
                        {
                            DateTime newDateChosen = new DateTime();
                            if (Convert.ToDateTime(item) != null)
                            {
                                newDateChosen = Convert.ToDateTime(item);
                                string newDateChosenString = newDateChosen.Year + "-" + newDateChosen.Month + "-" + newDateChosen.Day;
                                await GetNasaImagesByDate(newDateChosenString, displayImagesList);
                            }
                        }
                        catch
                        {

                        }

                    }
                }
                return displayImagesList;
            }
            catch
            {
                return displayImagesList;
            }
        }


        public async Task<List<DisplayImages>> GetFirstFifteenNasaImagesByDate(string dateChosen, List<DisplayImages> displayImagesList)
        {
            try
            {
                MarsRoverImage marsRoverImage = new MarsRoverImage();
                HttpClient client = _api.Initial();
                HttpResponseMessage responseMessage = await client.GetAsync("api/v1/rovers/curiosity/photos?earth_date=" + dateChosen + "&api_key=gVnoxQADOqBDAVopaZlfEhYtL7gNSxrXrQDruJDv");
                if (responseMessage.IsSuccessStatusCode)
                {
                    var resultString = responseMessage.Content.ReadAsStringAsync().Result;
                    marsRoverImage = JsonConvert.DeserializeObject<MarsRoverImage>(resultString);
                    int count = 0;

                    foreach (var item in marsRoverImage.PhotoList)
                    {
                        if (count < 5)
                        {
                            try
                            {
                                using (WebClient currentClient = new WebClient())
                                {
                                    currentClient.DownloadFile(new Uri(item.img_src), Path.GetFullPath("wwwroot/Images/NasaPic" + item.id + ".png"));
                                    DisplayImages displayImages = new DisplayImages();
                                    displayImages.ImageName = "NasaPic" + item.id + ".png";
                                    displayImagesList.Add(displayImages);
                                }
                            }
                            catch
                            {

                            }
                        }
                        else
                        {
                            break;
                        }
                        count++;
                    }
                }
                return displayImagesList;
            }
            catch
            {
                return displayImagesList;
            }
        }

        public async Task<List<DisplayImages>> GetFirstFifteenNasaImagesByDateArray(List<DisplayImages> displayImagesList)
        {
            try
            {
                using (StreamReader sr = new StreamReader(Path.GetFullPath("wwwroot/TextFile/dates.txt")))
                {
                    string line = sr.ReadToEnd();
                    string[] dateStringArray = line.Split("\n");

                    foreach (var item in dateStringArray)
                    {
                        try
                        {
                            DateTime newDateChosen = new DateTime();
                            if (Convert.ToDateTime(item) != null)
                            {
                                newDateChosen = Convert.ToDateTime(item);
                                string newDateChosenString = newDateChosen.Year + "-" + newDateChosen.Month + "-" + newDateChosen.Day;
                                await GetFirstFifteenNasaImagesByDate(newDateChosenString, displayImagesList);
                            }
                        }
                        catch
                        {

                        }

                    }
                }
                return displayImagesList;
            }
            catch
            {
                return displayImagesList;
            }
        }


    }
}
