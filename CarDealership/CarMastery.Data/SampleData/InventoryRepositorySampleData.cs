using CarMastery.Data.Interfaces;
using CarMastery.Models.Queries;
using CarMastery.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarMastery.Data.SampleData
{
    public class InventoryRepositorySampleData : IInventoryRepository
    {
        public static List<VehicleSearchResult> _Vehicles = new List<VehicleSearchResult>
        {
            new VehicleSearchResult
            {
                VehicleId =1, VehicleYear = 2018, MakeDescription = "Ford", ModelDescription= "Explorer",
                    BodyStyleDescription="SUV", InteriorColorDescription= "Light Gray", TransmissionDescription = "Automatic", VehicleTypeDescription = "New",
                    VehicleMileage=0, BodyColorDescription = "Silver", VehicleVIN = "11111111111111111", VehicleSalesPrice = 34000, VehicleMSRP = 35000,
                    VehiclePicture = "inventory-1.PNG", VehicleDescription = "Special1 Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vestibulum magna arcu, congue sit amet mattis quis, molestie a sem.  Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vestibulum magna arcu, congue sit amet mattis quis, molestie a sem.  Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vestibulum magna arcu, congue sit amet mattis quis, molestie a sem.", VehicleIsFeatured = false
            },
            new VehicleSearchResult
            {
                VehicleId =3, VehicleYear = 2018, MakeDescription = "Lincoln",ModelDescription= "Continental",
                    BodyStyleDescription="Car", InteriorColorDescription= "Light Gray", TransmissionDescription = "Manual", VehicleTypeDescription = "New",
                    VehicleMileage=200, BodyColorDescription = "Silver", VehicleVIN = "33333333333333333", VehicleSalesPrice = 44000, VehicleMSRP = 46000,
                    VehiclePicture = "inventory-3.PNG", VehicleDescription = "Test3 Lorem ipsum dolor sit amet, consectetur adipiscing elit.", VehicleIsFeatured = true
            },
           new VehicleSearchResult
            {
                VehicleId =8, VehicleYear = 2018, MakeDescription = "Chevrolet", ModelDescription= "Cruze",
                    BodyStyleDescription="car", InteriorColorDescription= "Light Gray", TransmissionDescription = "Automatic", VehicleTypeDescription = "New",
                    VehicleMileage=100, BodyColorDescription = "Silver", VehicleVIN = "88888888888888888", VehicleSalesPrice = 16000, VehicleMSRP = 17000,
                    VehiclePicture = "inventory-8.PNG", VehicleDescription = "Test8 Lorem ipsum dolor sit amet, consectetur adipiscing elit.", VehicleIsFeatured = false
            },
           new VehicleSearchResult
            {
                VehicleId =9, VehicleYear = 2018, MakeDescription = "Lincoln", ModelDescription= "Navigator",
                    BodyStyleDescription="SUV", InteriorColorDescription= "Light Gray", TransmissionDescription = "Automatic", VehicleTypeDescription = "New",
                    VehicleMileage=0, BodyColorDescription = "Silver", VehicleVIN = "99999999999999999", VehicleSalesPrice = 35000, VehicleMSRP = 36500,
                    VehiclePicture = "inventory-9.PNG", VehicleDescription = "Test9 Lorem ipsum dolor sit amet, consectetur adipiscing elit.", VehicleIsFeatured = true
            },
           new VehicleSearchResult
            {
                VehicleId =14, VehicleYear = 2018, MakeDescription = "Lincoln", ModelDescription= "Navigator",
                    BodyStyleDescription="SUV", InteriorColorDescription= "Light Gray", TransmissionDescription = "Automatic", VehicleTypeDescription = "New",
                    VehicleMileage=0, BodyColorDescription = "Silver", VehicleVIN = "14111111111111111", VehicleSalesPrice = 35000, VehicleMSRP = 36500,
                    VehiclePicture = "inventory-14.PNG", VehicleDescription = "Test14 Lorem ipsum dolor sit amet, consectetur adipiscing elit.", VehicleIsFeatured = true
            },
            new VehicleSearchResult
            {
                VehicleId =2, VehicleYear = 2016, MakeDescription = "Ford", ModelDescription= "F-150",
                   BodyStyleDescription="Truck", InteriorColorDescription= "Light Gray", TransmissionDescription = "Manual", VehicleTypeDescription = "Used",
                    VehicleMileage=50000, BodyColorDescription = "Silver", VehicleVIN = "22222222222222222", VehicleSalesPrice = 13500, VehicleMSRP = 14000,
                    VehiclePicture = "inventory-2.PNG", VehicleDescription = "Test2 Lorem ipsum dolor sit amet, consectetur adipiscing elit.", VehicleIsFeatured = false
            },
           new VehicleSearchResult
            {
                VehicleId =6, VehicleYear = 2016, MakeDescription = "Chevrolet", ModelDescription= "Express",
                    BodyStyleDescription="Van", InteriorColorDescription= "Light Gray", TransmissionDescription = "Automatic", VehicleTypeDescription = "Used",
                    VehicleMileage=50000, BodyColorDescription = "Silver", VehicleVIN = "66666666666666666", VehicleSalesPrice = 15000, VehicleMSRP = 16000,
                    VehiclePicture = "inventory-6.PNG", VehicleDescription = "Test6 Lorem ipsum dolor sit amet, consectetur adipiscing elit.", VehicleIsFeatured = true
            },
           new VehicleSearchResult
            {
                VehicleId =7, VehicleYear = 2016, MakeDescription = "Chevrolet", ModelDescription= "Tahoe",
                    BodyStyleDescription="SUV", InteriorColorDescription= "Light Gray", TransmissionDescription = "Automatic", VehicleTypeDescription = "Used",
                    VehicleMileage=50000, BodyColorDescription = "Silver", VehicleVIN = "7777777777777777", VehicleSalesPrice = 23000, VehicleMSRP = 24000,
                    VehiclePicture = "inventory-7.PNG", VehicleDescription = "Test7 Lorem ipsum dolor sit amet, consectetur adipiscing elit.", VehicleIsFeatured = false
            },
                      new VehicleSearchResult
            {
                VehicleId =12, VehicleYear = 2016, MakeDescription = "Ford", ModelDescription= "Transit Connect",
                    BodyStyleDescription="Van",InteriorColorDescription= "Light Gray", TransmissionDescription = "Manual", VehicleTypeDescription = "Used",
                    VehicleMileage=50000, BodyColorDescription = "Silver", VehicleVIN = "12111111111111111", VehicleSalesPrice = 14500, VehicleMSRP = 15000,
                    VehiclePicture = "inventory-12.PNG", VehicleDescription = "Test12 Lorem ipsum dolor sit amet, consectetur adipiscing elit.", VehicleIsFeatured = true
            },
           new VehicleSearchResult
            {
                VehicleId =13, VehicleYear = 2016, MakeDescription = "Ford", ModelDescription= "TransitConnect",
                    BodyStyleDescription="Van", InteriorColorDescription= "Light Gray", TransmissionDescription = "Manual", VehicleTypeDescription = "Used",
                    VehicleMileage=50000, BodyColorDescription = "Silver", VehicleVIN = "13111111111111111", VehicleSalesPrice = 14500, VehicleMSRP = 15000,
                    VehiclePicture = "inventory-13.PNG", VehicleDescription = "Test13 Lorem ipsum dolor sit amet, consectetur adipiscing elit.", VehicleIsFeatured = true
            },
            new VehicleSearchResult
            {
                VehicleId =15, VehicleYear = 2017, MakeDescription = "Lincoln",ModelDescription= "Continental",
                    BodyStyleDescription="Car", InteriorColorDescription= "Light Gray", TransmissionDescription = "Manual", VehicleTypeDescription = "New",
                    VehicleMileage=200, BodyColorDescription = "Silver", VehicleVIN = "15111111111111111", VehicleSalesPrice = 50000, VehicleMSRP = 51000,
                    VehiclePicture = "inventory-15.PNG", VehicleDescription = "Test15 Lorem ipsum dolor sit amet, consectetur adipiscing elit.", VehicleIsFeatured = false
            },
            new VehicleSearchResult
            {
                VehicleId =16, VehicleYear = 2001, MakeDescription = "Chevrolet",ModelDescription= "Cruze",
                    BodyStyleDescription="Car", InteriorColorDescription= "Light Gray", TransmissionDescription = "Manual", VehicleTypeDescription = "Used",
                    VehicleMileage=102000, BodyColorDescription = "Silver", VehicleVIN = "16111111111111111", VehicleSalesPrice = 9500, VehicleMSRP = 10000,
                    VehiclePicture = "inventory-16.PNG", VehicleDescription = "Test16 Lorem ipsum dolor sit amet, consectetur adipiscing elit.", VehicleIsFeatured = false
            },
                        new VehicleSearchResult
            {
                VehicleId =17, VehicleYear = 2002, MakeDescription = "Chevrolet",ModelDescription= "Silverado",
                    BodyStyleDescription="Car", InteriorColorDescription= "Light Gray", TransmissionDescription = "Manual", VehicleTypeDescription = "Used",
                    VehicleMileage=2000, BodyColorDescription = "Silver", VehicleVIN = "17111111111111111", VehicleSalesPrice = 19500, VehicleMSRP = 20000,
                    VehiclePicture = "inventory-17.PNG", VehicleDescription = "Test17 Lorem ipsum dolor sit amet, consectetur adipiscing elit.", VehicleIsFeatured = false
            },
            new VehicleSearchResult
            {
                VehicleId =18, VehicleYear = 2003, MakeDescription = "Chevrolet",ModelDescription= "Tahoe",
                    BodyStyleDescription="Car", InteriorColorDescription= "Light Gray", TransmissionDescription = "Manual", VehicleTypeDescription = "Used",
                    VehicleMileage=2000, BodyColorDescription = "Silver", VehicleVIN = "18111111111111111", VehicleSalesPrice = 29500, VehicleMSRP = 30000,
                    VehiclePicture = "inventory-18.PNG", VehicleDescription = "Test18 Lorem ipsum dolor sit amet, consectetur adipiscing elit.", VehicleIsFeatured = false
            },
                        new VehicleSearchResult
            {
                VehicleId =19, VehicleYear = 2004, MakeDescription = "Chevrolet",ModelDescription= "Express",
                    BodyStyleDescription="Car", InteriorColorDescription= "Light Gray", TransmissionDescription = "Manual", VehicleTypeDescription = "Used",
                    VehicleMileage=2000, BodyColorDescription = "Silver", VehicleVIN = "19111111111111111", VehicleSalesPrice = 39500, VehicleMSRP = 40000,
                    VehiclePicture = "inventory-19.PNG", VehicleDescription = "Test19 Lorem ipsum dolor sit amet, consectetur adipiscing elit.", VehicleIsFeatured = false
            },
            new VehicleSearchResult
            {
                VehicleId =20, VehicleYear = 2005, MakeDescription = "Ford",ModelDescription= "Fusion",
                    BodyStyleDescription="Car", InteriorColorDescription= "Light Gray", TransmissionDescription = "Manual", VehicleTypeDescription = "Used",
                    VehicleMileage=2000, BodyColorDescription = "Silver", VehicleVIN = "20111111111111111", VehicleSalesPrice = 49500, VehicleMSRP = 50000,
                    VehiclePicture = "inventory-20.PNG", VehicleDescription = "Test20 Lorem ipsum dolor sit amet, consectetur adipiscing elit.", VehicleIsFeatured = false
            },
            new VehicleSearchResult
            {
                VehicleId =21, VehicleYear = 2006, MakeDescription = "Ford",ModelDescription= "F-150",
                    BodyStyleDescription="Car", InteriorColorDescription= "Light Gray", TransmissionDescription = "Manual", VehicleTypeDescription = "Used",
                    VehicleMileage=2000, BodyColorDescription = "Silver", VehicleVIN = "21111111111111111", VehicleSalesPrice = 59500, VehicleMSRP = 60000,
                    VehiclePicture = "inventory-21.PNG", VehicleDescription = "Test21 Lorem ipsum dolor sit amet, consectetur adipiscing elit.", VehicleIsFeatured = false
            },
                        new VehicleSearchResult
            {
                VehicleId =22, VehicleYear = 2007, MakeDescription = "Ford",ModelDescription= "Explorer",
                    BodyStyleDescription="Car", InteriorColorDescription= "Light Gray", TransmissionDescription = "Manual", VehicleTypeDescription = "Used",
                    VehicleMileage=2000, BodyColorDescription = "Silver", VehicleVIN = "22111111111111111", VehicleSalesPrice = 69500, VehicleMSRP = 70000,
                    VehiclePicture = "inventory-22.PNG", VehicleDescription = "Test22 Lorem ipsum dolor sit amet, consectetur adipiscing elit.", VehicleIsFeatured = false
            },
            new VehicleSearchResult
            {
                VehicleId =23, VehicleYear = 2008, MakeDescription = "Ford",ModelDescription= "Transit Connect",
                    BodyStyleDescription="Car", InteriorColorDescription= "Light Gray", TransmissionDescription = "Manual", VehicleTypeDescription = "Used",
                    VehicleMileage=2000, BodyColorDescription = "Silver", VehicleVIN = "23111111111111111", VehicleSalesPrice = 79500, VehicleMSRP = 80000,
                    VehiclePicture = "inventory-23.PNG", VehicleDescription = "Test23 Lorem ipsum dolor sit amet, consectetur adipiscing elit.", VehicleIsFeatured = false
            },
            new VehicleSearchResult
            {
                VehicleId =24, VehicleYear = 2009, MakeDescription = "Lincoln",ModelDescription= "Continental",
                    BodyStyleDescription="Car", InteriorColorDescription= "Light Gray", TransmissionDescription = "Manual", VehicleTypeDescription = "Used",
                    VehicleMileage=2000, BodyColorDescription = "Silver", VehicleVIN = "24111111111111111", VehicleSalesPrice = 89500, VehicleMSRP = 90000,
                    VehiclePicture = "inventory-24.PNG", VehicleDescription = "Test24 Lorem ipsum dolor sit amet, consectetur adipiscing elit.", VehicleIsFeatured = false
            },
                        new VehicleSearchResult
            {
                VehicleId =25, VehicleYear = 2010, MakeDescription = "Lincoln",ModelDescription= "MKZ",
                    BodyStyleDescription="Car", InteriorColorDescription= "Light Gray", TransmissionDescription = "Manual", VehicleTypeDescription = "Used",
                    VehicleMileage=2000, BodyColorDescription = "Silver", VehicleVIN = "25111111111111111", VehicleSalesPrice = 7500, VehicleMSRP = 8000,
                    VehiclePicture = "inventory-25.PNG", VehicleDescription = "Test25 Lorem ipsum dolor sit amet, consectetur adipiscing elit.", VehicleIsFeatured = false
            },
            new VehicleSearchResult
            {
                VehicleId =26, VehicleYear = 2011, MakeDescription = "Lincoln",ModelDescription= "Navigator",
                    BodyStyleDescription="Car", InteriorColorDescription= "Light Gray", TransmissionDescription = "Manual", VehicleTypeDescription = "Used",
                    VehicleMileage=2000, BodyColorDescription = "Silver", VehicleVIN = "26111111111111111", VehicleSalesPrice = 14500, VehicleMSRP = 15000,
                    VehiclePicture = "inventory-26.PNG", VehicleDescription = "Test26 Lorem ipsum dolor sit amet, consectetur adipiscing elit.", VehicleIsFeatured = false
            },
            new VehicleSearchResult
            {
                VehicleId =27, VehicleYear = 2012, MakeDescription = "Chevrolet",ModelDescription= "Cruze",
                    BodyStyleDescription="Car", InteriorColorDescription= "Light Gray", TransmissionDescription = "Manual", VehicleTypeDescription = "Used",
                    VehicleMileage=2000, BodyColorDescription = "Silver", VehicleVIN = "27111111111111111", VehicleSalesPrice = 25500, VehicleMSRP = 30000,
                    VehiclePicture = "inventory-27.PNG", VehicleDescription = "Test27 Lorem ipsum dolor sit amet, consectetur adipiscing elit.", VehicleIsFeatured = false
            },
            new VehicleSearchResult
            {
                VehicleId =28, VehicleYear = 2013, MakeDescription = "Chevrolet",ModelDescription= "Silverado",
                    BodyStyleDescription="Car", InteriorColorDescription= "Light Gray", TransmissionDescription = "Manual", VehicleTypeDescription = "Used",
                    VehicleMileage=2000, BodyColorDescription = "Silver", VehicleVIN = "28111111111111111", VehicleSalesPrice = 51500, VehicleMSRP = 52000,
                    VehiclePicture = "inventory-28.PNG", VehicleDescription = "Test28 Lorem ipsum dolor sit amet, consectetur adipiscing elit.", VehicleIsFeatured = false
            },
                        new VehicleSearchResult
            {
                VehicleId =29, VehicleYear = 2014, MakeDescription = "Chevrolet",ModelDescription= "Tahoe",
                    BodyStyleDescription="Car", InteriorColorDescription= "Light Gray", TransmissionDescription = "Manual", VehicleTypeDescription = "Used",
                    VehicleMileage=2000, BodyColorDescription = "Silver", VehicleVIN = "29111111111111111", VehicleSalesPrice = 76500, VehicleMSRP = 77000,
                    VehiclePicture = "inventory-29.PNG", VehicleDescription = "Test29 Lorem ipsum dolor sit amet, consectetur adipiscing elit.", VehicleIsFeatured = false
            },
            new VehicleSearchResult
            {
                VehicleId =30, VehicleYear = 2015, MakeDescription = "Chevrolet",ModelDescription= "Express",
                    BodyStyleDescription="Car", InteriorColorDescription= "Light Gray", TransmissionDescription = "Manual", VehicleTypeDescription = "Used",
                    VehicleMileage=2000, BodyColorDescription = "Silver", VehicleVIN = "30111111111111111", VehicleSalesPrice = 62500, VehicleMSRP = 63000,
                    VehiclePicture = "inventory-30.PNG", VehicleDescription = "Test30 Lorem ipsum dolor sit amet, consectetur adipiscing elit.", VehicleIsFeatured = false
            },
                        new VehicleSearchResult
            {
                VehicleId =31, VehicleYear = 2016, MakeDescription = "Ford",ModelDescription= "Fusion",
                    BodyStyleDescription="Car", InteriorColorDescription= "Light Gray", TransmissionDescription = "Manual", VehicleTypeDescription = "Used",
                    VehicleMileage=2000, BodyColorDescription = "Silver", VehicleVIN = "31111111111111111", VehicleSalesPrice = 38500, VehicleMSRP = 39000,
                    VehiclePicture = "inventory-31.PNG", VehicleDescription = "Test31 Lorem ipsum dolor sit amet, consectetur adipiscing elit.", VehicleIsFeatured = false
            },
            new VehicleSearchResult
            {
                VehicleId =32, VehicleYear = 2017, MakeDescription = "Ford",ModelDescription= "F-150",
                    BodyStyleDescription="Car", InteriorColorDescription= "Light Gray", TransmissionDescription = "Manual", VehicleTypeDescription = "Used",
                    VehicleMileage=2000, BodyColorDescription = "Silver", VehicleVIN = "32111111111111111", VehicleSalesPrice = 45500, VehicleMSRP = 46000,
                    VehiclePicture = "inventory-32.PNG", VehicleDescription = "Test32 Lorem ipsum dolor sit amet, consectetur adipiscing elit.", VehicleIsFeatured = false
            },
                        new VehicleSearchResult
            {
                VehicleId =33, VehicleYear = 2009, MakeDescription = "Ford",ModelDescription= "Explorer",
                    BodyStyleDescription="Car", InteriorColorDescription= "Light Gray", TransmissionDescription = "Manual", VehicleTypeDescription = "Used",
                    VehicleMileage=2000, BodyColorDescription = "Silver", VehicleVIN = "33111111111111111", VehicleSalesPrice = 87500, VehicleMSRP = 88000,
                    VehiclePicture = "inventory-33.PNG", VehicleDescription = "Test33 Lorem ipsum dolor sit amet, consectetur adipiscing elit.", VehicleIsFeatured = false
            },
            new VehicleSearchResult
            {
                VehicleId =34, VehicleYear = 2014, MakeDescription = "Ford",ModelDescription= "Transit Connect",
                    BodyStyleDescription="Car", InteriorColorDescription= "Light Gray", TransmissionDescription = "Manual", VehicleTypeDescription = "Used",
                    VehicleMileage=2000, BodyColorDescription = "Silver", VehicleVIN = "34111111111111111", VehicleSalesPrice = 95500, VehicleMSRP = 96000,
                    VehiclePicture = "inventory-34.PNG", VehicleDescription = "Test34 Lorem ipsum dolor sit amet, consectetur adipiscing elit.", VehicleIsFeatured = false
            },
            new VehicleSearchResult
            {
                VehicleId =35, VehicleYear = 2001, MakeDescription = "Lincoln",ModelDescription= "Continental",
                    BodyStyleDescription="Car", InteriorColorDescription= "Light Gray", TransmissionDescription = "Manual", VehicleTypeDescription = "Used",
                    VehicleMileage=2000, BodyColorDescription = "Silver", VehicleVIN = "35111111111111111", VehicleSalesPrice = 21500, VehicleMSRP = 22000,
                    VehiclePicture = "inventory-35.PNG", VehicleDescription = "Test35 Lorem ipsum dolor sit amet, consectetur adipiscing elit.", VehicleIsFeatured = false
            },
            new VehicleSearchResult
            {
                VehicleId =100000, VehicleYear = 2001, MakeDescription = "Lincoln",ModelDescription= "Continental",
                    BodyStyleDescription="Car", InteriorColorDescription= "Light Gray", TransmissionDescription = "Manual", VehicleTypeDescription = "Used",
                    VehicleMileage=2000, BodyColorDescription = "Silver", VehicleVIN = "10000011111111111", VehicleSalesPrice = 21500, VehicleMSRP = 22000,
                    VehiclePicture = "inventory-35.PNG", VehicleDescription = "Test35 Lorem ipsum dolor sit amet, consectetur adipiscing elit.", VehicleIsFeatured = false
            }

        };

        public static List<Sales> _Sales = new List<Sales>
        {
 
            new Sales
            { SaleId = 5, CustomerId = 1, VehicleId = 100000, FinancingId = 1, UserId = "22222222-2222-2222-2222-222222222222", SaleAmount = 10000, SaleDate = DateTime.Parse("2018-01-25 00:00:00.0000000")}
        };

        public IEnumerable<InventoryReport> CreateNewInventoryReport()
        {
            var result =
                from v in _Vehicles
                where v.VehicleTypeDescription == "New"
                group v by new
                {
                    v.VehicleYear,
                    v.MakeDescription,
                    v.ModelDescription,
                } into ymm
                select new InventoryReport()
                {

                    VehicleYear = ymm.Key.VehicleYear,
                    MakeDescription = ymm.Key.MakeDescription,
                    ModelDescription = ymm.Key.ModelDescription,
                    Count = ymm.Count(),
                    StockValue = ymm.Sum(v => v.VehicleMSRP),
                };

            var newInventoryReport = result.OrderBy(y => y.VehicleYear).ThenBy(make => make.MakeDescription).ThenBy(model => model.ModelDescription);
            return newInventoryReport;
        }

        public IEnumerable<InventoryReport> CreateUsedInventoryReport()
        {
            var result =
                from v in _Vehicles
                where v.VehicleTypeDescription == "Used"
                orderby (v.VehicleYear)
                group v by new
                {
                    v.VehicleYear,
                    v.MakeDescription,
                    v.ModelDescription,
                } into ymm
                select new InventoryReport()
                {

                    VehicleYear = ymm.Key.VehicleYear,
                    MakeDescription = ymm.Key.MakeDescription,
                    ModelDescription = ymm.Key.ModelDescription,
                    Count = ymm.Count(),
                    StockValue = ymm.Sum(v => v.VehicleMSRP),
                };
            var usedInventoryReport = result.OrderBy(y => y.VehicleYear).ThenBy(make => make.MakeDescription).ThenBy(model => model.ModelDescription);

            return usedInventoryReport;
        }

        public IEnumerable<FeaturedVehicleShortItem> GetFeaturedVehicles()
        {
            List<FeaturedVehicleShortItem> list = new List<FeaturedVehicleShortItem>();

            foreach (var vehicle in _Vehicles)
            {
                if (vehicle.VehicleIsFeatured == true)
                {
                    FeaturedVehicleShortItem currentRow = new FeaturedVehicleShortItem();
                    currentRow.VehicleId = vehicle.VehicleId;
                    currentRow.VehicleYear = vehicle.VehicleYear;
                    currentRow.MakeDescription = vehicle.MakeDescription;
                    currentRow.ModelDescription = vehicle.ModelDescription;
                    currentRow.VehicleSalesPrice = vehicle.VehicleSalesPrice;
                    currentRow.VehiclePicture = vehicle.VehiclePicture;

                    list.Add(currentRow);
                }
            }
            return list;
        }

        public VehicleSearchResult GetVehicleDetails(int vehicleId)
        {
            VehicleSearchResult vehicle = _Vehicles.FirstOrDefault(v => v.VehicleId == vehicleId);

            vehicle.VehicleSalesPriceFormatted = vehicle.VehicleSalesPrice.ToString("c0");
            vehicle.VehicleMSRPFormatted = vehicle.VehicleMSRP.ToString("c0");
            if (vehicle.VehicleMileage < 1000)
                vehicle.VehicleMileageFormatted = "New";
            else
                vehicle.VehicleMileageFormatted = Convert.ToDecimal(vehicle.VehicleMileage).ToString("#,##0");
            vehicle.VehicleIsSold = IsSold(vehicle.VehicleId);

            return vehicle;
        }

        public bool IsSold(int vehicleId)
        {
            if (_Sales.Where(s => s.VehicleId == vehicleId).Any())
                return true;
            else
                return false;
        }

        public IEnumerable<VehicleSearchResult> SearchInventory(VehicleSearchParameters parameters)
        {
            {
                List<VehicleSearchResult> list = new List<VehicleSearchResult>();

                if (string.IsNullOrEmpty(parameters.MinPrice.ToString()))
                    parameters.MinPrice = 1;

                if (string.IsNullOrEmpty(parameters.MaxPrice.ToString()))
                    parameters.MaxPrice = 150000;

                if (string.IsNullOrEmpty(parameters.MinYear.ToString()))
                    parameters.MinYear = 1999;

                if (string.IsNullOrEmpty(parameters.MaxYear.ToString()))
                    parameters.MaxYear = 3000;
                
                if (!string.IsNullOrEmpty(parameters.MakeModelYear) && int.TryParse(parameters.MakeModelYear, out int year))
                {
                    parameters.MakeModelYear = year.ToString();
                }
                else if (string.IsNullOrEmpty(parameters.MakeModelYear))
                    parameters.MakeModelYear = "";
                
                if (string.IsNullOrEmpty(parameters.NewUsed))
                {
                    var result = _Vehicles.
                                 Where(v => (v.MakeDescription.StartsWith(parameters.MakeModelYear) || v.VehicleYear.ToString().StartsWith(parameters.MakeModelYear) || v.ModelDescription.StartsWith(parameters.MakeModelYear)) &&v.VehicleYear >= parameters.MinYear && v.VehicleYear <= parameters.MaxYear && v.VehicleSalesPrice >= parameters.MinPrice && v.VehicleSalesPrice <= parameters.MaxPrice);

                    var newInventoryQuery = result.OrderByDescending(v => v.VehicleSalesPrice).Take(20);

                    foreach (VehicleSearchResult vehicle in newInventoryQuery)
                    {
                        vehicle.VehicleSalesPriceFormatted = vehicle.VehicleSalesPrice.ToString("c0");
                        vehicle.VehicleMSRPFormatted = vehicle.VehicleMSRP.ToString("c0");
                        if (vehicle.VehicleMileage < 1000)
                            vehicle.VehicleMileageFormatted = "New";
                        else
                            vehicle.VehicleMileageFormatted = Convert.ToDecimal(vehicle.VehicleMileage).ToString("#,##0");
                    }

                    return newInventoryQuery;
                }
                else 
                {
                    var result = _Vehicles.
                                 Where(v => v.VehicleTypeDescription == parameters.NewUsed && (v.MakeDescription.StartsWith(parameters.MakeModelYear) || v.VehicleYear.ToString().StartsWith(parameters.MakeModelYear) || v.ModelDescription.StartsWith(parameters.MakeModelYear)) && v.VehicleYear >= parameters.MinYear && v.VehicleYear <= parameters.MaxYear && v.VehicleSalesPrice >= parameters.MinPrice && v.VehicleSalesPrice <= parameters.MaxPrice);

                    var newInventoryQuery = result.OrderByDescending(v => v.VehicleSalesPrice).Take(20);

                    foreach (VehicleSearchResult vehicle in newInventoryQuery)
                    {
                        vehicle.VehicleSalesPriceFormatted = vehicle.VehicleSalesPrice.ToString("c0");
                        vehicle.VehicleMSRPFormatted = vehicle.VehicleMSRP.ToString("c0");
                         if (vehicle.VehicleMileage < 1000)
                             vehicle.VehicleMileageFormatted = "New";
                         else
                             vehicle.VehicleMileageFormatted = Convert.ToDecimal(vehicle.VehicleMileage).ToString("#,##0");
                    }

                    return newInventoryQuery;
                }
            }
        }
    }
}
