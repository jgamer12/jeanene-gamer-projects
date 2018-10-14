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
    public class VehiclesRepositorySampleData : IVehiclesRepository
    {
         public static List<Vehicles> _Vehicles = new List<Vehicles>
        {
            new Vehicles
            {
                VehicleId =1, VehicleYear = 2018, ModelId= 7, VehicleTypeId = 1, BodyStyleId=2, InteriorColorId= 4, TransmissionId = 1,
                    VehicleMileage=0, BodyColorId = 2, VehicleVIN = "11111111111111111", VehicleSalesPrice = 34000, VehicleMSRP = 35000,
                    VehiclePicture = "inventory-1.PNG", VehicleDescription = "Special1 Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vestibulum magna arcu, congue sit amet mattis quis, molestie a sem.  Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vestibulum magna arcu, congue sit amet mattis quis, molestie a sem.  Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vestibulum magna arcu, congue sit amet mattis quis, molestie a sem.", VehicleIsFeatured = false
            },
            new Vehicles
            {
                VehicleId =2, VehicleYear = 2016, ModelId= 6, VehicleTypeId = 2, BodyStyleId=3, InteriorColorId= 4, TransmissionId = 2,
                    VehicleMileage=50000, BodyColorId = 2, VehicleVIN = "22222222222222222", VehicleSalesPrice = 13500, VehicleMSRP = 14000,
                    VehiclePicture = "inventory-2.PNG", VehicleDescription = "Test2 Lorem ipsum dolor sit amet, consectetur adipiscing elit.", VehicleIsFeatured = false
            },
            new Vehicles
            {
                VehicleId =3, VehicleYear = 2018, ModelId = 9, VehicleTypeId = 1, BodyStyleId =1, InteriorColorId = 4, TransmissionId = 2,
                    VehicleMileage=200, BodyColorId = 2, VehicleVIN = "33333333333333333", VehicleSalesPrice = 44000, VehicleMSRP = 46000,
                    VehiclePicture = "inventory-3.PNG", VehicleDescription = "Test3 Lorem ipsum dolor sit amet, consectetur adipiscing elit.", VehicleIsFeatured = true
            },
           new Vehicles
            {
                VehicleId =4, VehicleYear = 2016, ModelId= 5, VehicleTypeId = 2, BodyStyleId=1, InteriorColorId= 4, TransmissionId = 1,
                    VehicleMileage=50000, BodyColorId = 2, VehicleVIN = "44444444444444444", VehicleSalesPrice = 10000, VehicleMSRP = 11500,
                    VehiclePicture = "inventory-4.PNG", VehicleDescription = "Test4 Lorem ipsum dolor sit amet, consectetur adipiscing elit.", VehicleIsFeatured = false
            },
           new Vehicles
            {
                VehicleId =5, VehicleYear = 2018, ModelId= 11, VehicleTypeId = 1, BodyStyleId=2, InteriorColorId= 4, TransmissionId = 1,
                    VehicleMileage=0, BodyColorId = 2, VehicleVIN = "55555555555555555", VehicleSalesPrice = 71000, VehicleMSRP = 73000,
                    VehiclePicture = "inventory-5.PNG", VehicleDescription = "Test5 Lorem ipsum dolor sit amet, consectetur adipiscing elit.", VehicleIsFeatured = false
            },
           new Vehicles
            {
                VehicleId =6, VehicleYear = 2016, ModelId= 4, VehicleTypeId = 2, BodyStyleId=4, InteriorColorId= 4, TransmissionId = 1,
                    VehicleMileage=50000, BodyColorId = 2, VehicleVIN = "66666666666666666", VehicleSalesPrice = 15000, VehicleMSRP = 16000,
                    VehiclePicture = "inventory-6.PNG", VehicleDescription = "Test6 Lorem ipsum dolor sit amet, consectetur adipiscing elit.", VehicleIsFeatured = true
            },
           new Vehicles
            {
                VehicleId =7, VehicleYear = 2016, ModelId= 3, VehicleTypeId = 2, BodyStyleId=2, InteriorColorId= 4, TransmissionId = 1,
                    VehicleMileage=50000, BodyColorId = 2, VehicleVIN = "7777777777777777", VehicleSalesPrice = 23000, VehicleMSRP = 24000,
                    VehiclePicture = "inventory-7.PNG", VehicleDescription = "Test7 Lorem ipsum dolor sit amet, consectetur adipiscing elit.", VehicleIsFeatured = false
            },
           new Vehicles
            {
                VehicleId =8, VehicleYear = 2018, ModelId= 1, VehicleTypeId = 1, BodyStyleId=1, InteriorColorId= 4, TransmissionId =1 ,
                    VehicleMileage=100, BodyColorId = 2, VehicleVIN = "88888888888888888", VehicleSalesPrice = 16000, VehicleMSRP = 17000,
                    VehiclePicture = "inventory-8.PNG", VehicleDescription = "Test8 Lorem ipsum dolor sit amet, consectetur adipiscing elit.", VehicleIsFeatured = false
            },
           new Vehicles
            {
                VehicleId =9, VehicleYear = 2018, ModelId= 11, VehicleTypeId = 1, BodyStyleId=2, InteriorColorId= 4, TransmissionId = 1,
                    VehicleMileage=0, BodyColorId = 2, VehicleVIN = "99999999999999999", VehicleSalesPrice = 35000, VehicleMSRP = 36500,
                    VehiclePicture = "inventory-9.PNG", VehicleDescription = "Test9 Lorem ipsum dolor sit amet, consectetur adipiscing elit.", VehicleIsFeatured = true
            },
           new Vehicles
            {
                VehicleId =10, VehicleYear = 2018, ModelId= 2, VehicleTypeId = 1, BodyStyleId=3, InteriorColorId= 4, TransmissionId = 2,
                    VehicleMileage=0, BodyColorId = 2, VehicleVIN = "10111111111111111", VehicleSalesPrice = 28000, VehicleMSRP = 29000,
                    VehiclePicture = "inventory-10.PNG", VehicleDescription = "Test10 Lorem ipsum dolor sit amet, consectetur adipiscing elit.", VehicleIsFeatured = false
            },
           new Vehicles
            {
                VehicleId =11, VehicleYear = 2016, ModelId= 10, VehicleTypeId = 2, BodyStyleId=1, InteriorColorId= 4, TransmissionId = 1,
                    VehicleMileage=50000, BodyColorId = 2, VehicleVIN = "11000000000000000", VehicleSalesPrice = 17000, VehicleMSRP = 18000,
                    VehiclePicture = "inventory-11.PNG", VehicleDescription = "Test11 Lorem ipsum dolor sit amet, consectetur adipiscing elit.", VehicleIsFeatured = false
            },
           new Vehicles
            {
                VehicleId =12, VehicleYear = 2016, ModelId= 8, VehicleTypeId = 2, BodyStyleId=4,InteriorColorId= 4, TransmissionId = 2,
                    VehicleMileage=50000, BodyColorId = 2, VehicleVIN = "12111111111111111", VehicleSalesPrice = 14500, VehicleMSRP = 17000,
                    VehiclePicture = "inventory-12.PNG", VehicleDescription = "Test12 Lorem ipsum dolor sit amet, consectetur adipiscing elit.", VehicleIsFeatured = true
            },
           new Vehicles
            {
                VehicleId =13, VehicleYear = 2016, ModelId= 8, VehicleTypeId = 2, BodyStyleId=4, InteriorColorId= 4, TransmissionId = 2,
                    VehicleMileage=50000, BodyColorId = 2, VehicleVIN = "13111111111111111", VehicleSalesPrice = 14500, VehicleMSRP = 17000,
                    VehiclePicture = "inventory-13.PNG", VehicleDescription = "Test13 Lorem ipsum dolor sit amet, consectetur adipiscing elit.", VehicleIsFeatured = true
            },
           new Vehicles
            {
                VehicleId =14, VehicleYear = 2018, ModelId= 11, VehicleTypeId = 1, BodyStyleId=2, InteriorColorId= 4, TransmissionId = 1,
                    VehicleMileage=0, BodyColorId = 2, VehicleVIN = "14111111111111111", VehicleSalesPrice = 35000, VehicleMSRP = 36500,
                    VehiclePicture = "inventory-14.PNG", VehicleDescription = "Test14 Lorem ipsum dolor sit amet, consectetur adipiscing elit.", VehicleIsFeatured = true
            },
            new Vehicles
            {
                VehicleId =100008, VehicleYear = 2018, ModelId= 11, VehicleTypeId = 1, BodyStyleId=2, InteriorColorId= 4, TransmissionId = 1,
                    VehicleMileage=0, BodyColorId = 2, VehicleVIN = "14111111111111111", VehicleSalesPrice = 35000, VehicleMSRP = 36500,
                    VehiclePicture = "inventory-1.PNG", VehicleDescription = "Test14 Lorem ipsum dolor sit amet, consectetur adipiscing elit.", VehicleIsFeatured = false
            },
            new Vehicles
            {
                VehicleId =15, VehicleYear = 2018, ModelId = 9, VehicleTypeId = 1, BodyStyleId =1, InteriorColorId = 4, TransmissionId = 2,
                    VehicleMileage=200, BodyColorId = 2, VehicleVIN = "15111111111111111", VehicleSalesPrice = 50000, VehicleMSRP = 51000,
                    VehiclePicture = "inventory-15.PNG", VehicleDescription = "Test15 Lorem ipsum dolor sit amet, consectetur adipiscing elit.", VehicleIsFeatured = false
            },
            new Vehicles
            {
                VehicleId =16, VehicleYear = 2001, ModelId = 1, VehicleTypeId = 2, BodyStyleId =1, InteriorColorId = 4, TransmissionId = 2,
                    VehicleMileage=2000, BodyColorId = 2, VehicleVIN = "16111111111111111", VehicleSalesPrice = 9500, VehicleMSRP = 10000,
                    VehiclePicture = "inventory-16.PNG", VehicleDescription = "Test16 Lorem ipsum dolor sit amet, consectetur adipiscing elit.", VehicleIsFeatured = false
            },
            new Vehicles
            {
                VehicleId =17, VehicleYear = 2002, ModelId = 2, VehicleTypeId = 2, BodyStyleId =3, InteriorColorId = 4, TransmissionId = 2,
                    VehicleMileage=2000, BodyColorId = 2, VehicleVIN = "17111111111111111", VehicleSalesPrice = 19500, VehicleMSRP = 20000,
                    VehiclePicture = "inventory-17.PNG", VehicleDescription = "Test17 Lorem ipsum dolor sit amet, consectetur adipiscing elit.", VehicleIsFeatured = false
            },
            new Vehicles
            {
                VehicleId =18, VehicleYear = 2003, ModelId = 3, VehicleTypeId = 2, BodyStyleId =2, InteriorColorId = 4, TransmissionId = 2,
                    VehicleMileage=2000, BodyColorId = 2, VehicleVIN = "18111111111111111", VehicleSalesPrice = 29500, VehicleMSRP = 30000,
                    VehiclePicture = "inventory-18.PNG", VehicleDescription = "Test18 Lorem ipsum dolor sit amet, consectetur adipiscing elit.", VehicleIsFeatured = false
            },
            new Vehicles
            {
                VehicleId =19, VehicleYear = 2004, ModelId = 4, VehicleTypeId = 2, BodyStyleId =4, InteriorColorId = 4, TransmissionId = 2,
                    VehicleMileage=2000, BodyColorId = 2, VehicleVIN = "19111111111111111", VehicleSalesPrice = 39500, VehicleMSRP = 40000,
                    VehiclePicture = "inventory-19.PNG", VehicleDescription = "Test19 Lorem ipsum dolor sit amet, consectetur adipiscing elit.", VehicleIsFeatured = false
            },
            new Vehicles
            {
                VehicleId =20, VehicleYear = 2005, ModelId = 5, VehicleTypeId = 2, BodyStyleId =1, InteriorColorId = 4, TransmissionId = 2,
                    VehicleMileage=2000, BodyColorId = 2, VehicleVIN = "20111111111111111", VehicleSalesPrice = 49500, VehicleMSRP = 50000,
                    VehiclePicture = "inventory-20.PNG", VehicleDescription = "Test20 Lorem ipsum dolor sit amet, consectetur adipiscing elit.", VehicleIsFeatured = false
            },
            new Vehicles
            {
                VehicleId =21, VehicleYear = 2006, ModelId = 6, VehicleTypeId = 2, BodyStyleId =3, InteriorColorId = 4, TransmissionId = 2,
                    VehicleMileage=2000, BodyColorId = 2, VehicleVIN = "21111111111111111", VehicleSalesPrice = 59500, VehicleMSRP = 60000,
                    VehiclePicture = "inventory-21.PNG", VehicleDescription = "Test21 Lorem ipsum dolor sit amet, consectetur adipiscing elit.", VehicleIsFeatured = false
            },
            new Vehicles
            {
                VehicleId =22, VehicleYear = 2007, ModelId = 7, VehicleTypeId = 2, BodyStyleId =2, InteriorColorId = 4, TransmissionId = 2,
                    VehicleMileage=2000, BodyColorId = 2, VehicleVIN = "22111111111111111", VehicleSalesPrice = 69500, VehicleMSRP = 70000,
                    VehiclePicture = "inventory-22.PNG", VehicleDescription = "Test22 Lorem ipsum dolor sit amet, consectetur adipiscing elit.", VehicleIsFeatured = false
            },
            new Vehicles
            {
                VehicleId =23, VehicleYear = 2008, ModelId = 8, VehicleTypeId = 2, BodyStyleId =4, InteriorColorId = 4, TransmissionId = 2,
                    VehicleMileage=2000, BodyColorId = 2, VehicleVIN = "2311111111111111", VehicleSalesPrice = 79500, VehicleMSRP = 80000,
                    VehiclePicture = "inventory-23.PNG", VehicleDescription = "Test23 Lorem ipsum dolor sit amet, consectetur adipiscing elit.", VehicleIsFeatured = false
            },
            new Vehicles
            {
                VehicleId =24, VehicleYear = 2009, ModelId = 9, VehicleTypeId = 2, BodyStyleId =1, InteriorColorId = 4, TransmissionId = 2,
                    VehicleMileage=2000, BodyColorId = 2, VehicleVIN = "24111111111111111", VehicleSalesPrice = 89500, VehicleMSRP = 90000,
                    VehiclePicture = "inventory-24.PNG", VehicleDescription = "Test24 Lorem ipsum dolor sit amet, consectetur adipiscing elit.", VehicleIsFeatured = false
            },
            new Vehicles
            {
                VehicleId =25, VehicleYear = 2010, ModelId = 10, VehicleTypeId = 2, BodyStyleId =1, InteriorColorId = 4, TransmissionId = 2,
                    VehicleMileage=2000, BodyColorId = 2, VehicleVIN = "25111111111111111", VehicleSalesPrice = 7500, VehicleMSRP = 8000,
                    VehiclePicture = "inventory-25.PNG", VehicleDescription = "Test25 Lorem ipsum dolor sit amet, consectetur adipiscing elit.", VehicleIsFeatured = false
            },
            new Vehicles
            {
                VehicleId =26, VehicleYear = 2011, ModelId = 11, VehicleTypeId = 2, BodyStyleId =2, InteriorColorId = 4, TransmissionId = 2,
                    VehicleMileage=2000, BodyColorId = 2, VehicleVIN = "26111111111111111", VehicleSalesPrice = 14500, VehicleMSRP = 15000,
                    VehiclePicture = "inventory-26.PNG", VehicleDescription = "Test26 Lorem ipsum dolor sit amet, consectetur adipiscing elit.", VehicleIsFeatured = false
            },
            new Vehicles
            {
                VehicleId =27, VehicleYear = 2012, ModelId = 1, VehicleTypeId = 2, BodyStyleId =1, InteriorColorId = 4, TransmissionId = 2,
                    VehicleMileage=2000, BodyColorId = 2, VehicleVIN = "27111111111111111", VehicleSalesPrice = 25500, VehicleMSRP = 26000,
                    VehiclePicture = "inventory-27.PNG", VehicleDescription = "Test27 Lorem ipsum dolor sit amet, consectetur adipiscing elit.", VehicleIsFeatured = false
            },
            new Vehicles
            {
                VehicleId =28, VehicleYear = 2013, ModelId = 2, VehicleTypeId = 2, BodyStyleId =3, InteriorColorId = 4, TransmissionId = 2,
                    VehicleMileage=2000, BodyColorId = 2, VehicleVIN = "28111111111111111", VehicleSalesPrice = 51500, VehicleMSRP = 52000,
                    VehiclePicture = "inventory-28.PNG", VehicleDescription = "Test28 Lorem ipsum dolor sit amet, consectetur adipiscing elit.", VehicleIsFeatured = false
            },
            new Vehicles
            {
                VehicleId =29, VehicleYear = 2014, ModelId = 3, VehicleTypeId = 2, BodyStyleId =2, InteriorColorId = 4, TransmissionId = 2,
                    VehicleMileage=2000, BodyColorId = 2, VehicleVIN = "29111111111111111", VehicleSalesPrice = 76500, VehicleMSRP = 77000,
                    VehiclePicture = "inventory-29.PNG", VehicleDescription = "Test29 Lorem ipsum dolor sit amet, consectetur adipiscing elit.", VehicleIsFeatured = false
            },
            new Vehicles
            {
                VehicleId =30, VehicleYear = 2015, ModelId = 4, VehicleTypeId = 2, BodyStyleId =4, InteriorColorId = 4, TransmissionId = 2,
                    VehicleMileage=2000, BodyColorId = 2, VehicleVIN = "30111111111111111", VehicleSalesPrice = 62500, VehicleMSRP = 63000,
                    VehiclePicture = "inventory-30.PNG", VehicleDescription = "Test30 Lorem ipsum dolor sit amet, consectetur adipiscing elit.", VehicleIsFeatured = false
            },
            new Vehicles
            {
                VehicleId =31, VehicleYear = 2016, ModelId = 5, VehicleTypeId = 2, BodyStyleId =1, InteriorColorId = 4, TransmissionId = 2,
                    VehicleMileage=2000, BodyColorId = 2, VehicleVIN = "31111111111111111", VehicleSalesPrice = 38500, VehicleMSRP = 39000,
                    VehiclePicture = "inventory-31.PNG", VehicleDescription = "Test31 Lorem ipsum dolor sit amet, consectetur adipiscing elit.", VehicleIsFeatured = false
            },
            new Vehicles
            {
                VehicleId =32, VehicleYear = 2017, ModelId = 6, VehicleTypeId = 2, BodyStyleId =3, InteriorColorId = 4, TransmissionId = 2,
                    VehicleMileage=2000, BodyColorId = 2, VehicleVIN = "32111111111111111", VehicleSalesPrice = 45500, VehicleMSRP = 46000,
                    VehiclePicture = "inventory-32.PNG", VehicleDescription = "Test32 Lorem ipsum dolor sit amet, consectetur adipiscing elit.", VehicleIsFeatured = false
            },
            new Vehicles
            {
                VehicleId =33, VehicleYear = 2009, ModelId = 7, VehicleTypeId = 2, BodyStyleId =2, InteriorColorId = 4, TransmissionId = 2,
                    VehicleMileage=2000, BodyColorId = 2, VehicleVIN = "33111111111111111", VehicleSalesPrice = 87500, VehicleMSRP = 88000,
                    VehiclePicture = "inventory-33.PNG", VehicleDescription = "Test33 Lorem ipsum dolor sit amet, consectetur adipiscing elit.", VehicleIsFeatured = false
            },
            new Vehicles
            {
                VehicleId =34, VehicleYear = 2014, ModelId = 8, VehicleTypeId = 2, BodyStyleId =4, InteriorColorId = 4, TransmissionId = 2,
                    VehicleMileage=2000, BodyColorId = 2, VehicleVIN = "34111111111111111", VehicleSalesPrice = 95500, VehicleMSRP = 96000,
                    VehiclePicture = "inventory-34.PNG", VehicleDescription = "Test34 Lorem ipsum dolor sit amet, consectetur adipiscing elit.", VehicleIsFeatured = false
            },
            new Vehicles
            {
                VehicleId =35, VehicleYear = 2001, ModelId = 9, VehicleTypeId = 2, BodyStyleId =1, InteriorColorId = 4, TransmissionId = 2,
                    VehicleMileage=2000, BodyColorId = 2, VehicleVIN = "3511111111111111", VehicleSalesPrice = 21500, VehicleMSRP = 22000,
                    VehiclePicture = "inventory-35.PNG", VehicleDescription = "Test35 Lorem ipsum dolor sit amet, consectetur adipiscing elit.", VehicleIsFeatured = false
            }
        };

        public static List<Models.Tables.Models> _Models = new List<Models.Tables.Models>
        {
            new Models.Tables.Models
                {ModelId = 1, MakeId=1, UserId="00000000-0000-0000-0000-000000000000", ModelDescription = "Cruze", ModelDateAdded = DateTime.Parse("2018-07-23 00:00:00.0000000")},
            new Models.Tables.Models
                {ModelId = 2, MakeId=1, UserId="00000000-0000-0000-0000-000000000000", ModelDescription = "Silverado", ModelDateAdded = DateTime.Parse("2018-07-23 00:00:00.0000000")},
            new Models.Tables.Models
                {ModelId = 3, MakeId=1, UserId="00000000-0000-0000-0000-000000000000", ModelDescription = "Tahoe", ModelDateAdded = DateTime.Parse("2018-03-22 00:00:00.0000000")},
            new Models.Tables.Models
                {ModelId = 4, MakeId=1, UserId="00000000-0000-0000-0000-000000000000", ModelDescription = "Express", ModelDateAdded = DateTime.Parse("2018-07-23 00:00:00.0000000")},
            new Models.Tables.Models
                {ModelId = 5, MakeId=2, UserId="00000000-0000-0000-0000-000000000000", ModelDescription = "Fusion", ModelDateAdded = DateTime.Parse("2018-07-23 00:00:00.0000000")},
            new Models.Tables.Models
                {ModelId = 6, MakeId=2, UserId="00000000-0000-0000-0000-000000000000", ModelDescription = "F-150", ModelDateAdded = DateTime.Parse("2018-07-23 00:00:00.0000000")},
            new Models.Tables.Models
                {ModelId = 7, MakeId=2, UserId="00000000-0000-0000-0000-000000000000", ModelDescription = "Explorer", ModelDateAdded = DateTime.Parse("2018-07-23 00:00:00.0000000")},
            new Models.Tables.Models
                {ModelId = 8, MakeId=2, UserId="00000000-0000-0000-0000-000000000000", ModelDescription = "Transit Connect", ModelDateAdded = DateTime.Parse("2018-07-23 00:00:00.0000000")},
            new Models.Tables.Models
                {ModelId = 9, MakeId=3, UserId="00000000-0000-0000-0000-000000000000", ModelDescription = "Continental", ModelDateAdded = DateTime.Parse("2018-07-23 00:00:00.0000000")},
            new Models.Tables.Models
                {ModelId = 10, MakeId=3, UserId="00000000-0000-0000-0000-000000000000", ModelDescription = "MKZ", ModelDateAdded = DateTime.Parse("2018-07-23 00:00:00.0000000")},
            new Models.Tables.Models
                {ModelId = 11, MakeId=3, UserId="00000000-0000-0000-0000-000000000000", ModelDescription = "Navigator", ModelDateAdded = DateTime.Parse("2018-07-23 00:00:00.0000000")},
        };

        public void AddVehicle(Vehicles vehicle)
        {
            vehicle.VehicleId = _Vehicles.Max(s => s.VehicleId) + 1;
            _Vehicles.Add(vehicle);
        }

        public void DeleteVehicle(int vehicleId)
        {
            _Vehicles.RemoveAll(v => v.VehicleId == vehicleId);
        }

        public int GetNextVehicleId()
        {
            var nextVehicleId = _Vehicles.Max(s => s.VehicleId) + 1;
            return nextVehicleId;            
        }

        public Vehicles SelectVehicle(int vehicleId)
        {
            Vehicles vehicle = _Vehicles.FirstOrDefault(v => v.VehicleId == vehicleId);            
            return vehicle;
        }

        public void UpdateVehicle(Vehicles vehicle)
        {

            DeleteVehicle(vehicle.VehicleId);
            _Vehicles.Add(vehicle);
        }
    }
}