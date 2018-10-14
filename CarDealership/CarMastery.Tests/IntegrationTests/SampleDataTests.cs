using CarMastery.Data.SampleData;
using CarMastery.Models.Queries;
using CarMastery.Models.Tables;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarMastery.Tests.IntegrationTests
{
    [TestFixture]
    public class SampleDataTests
    {
        [Test]
        public static void SampleDataCanLoadSpecials()
        {

            var repo = new SpecialsRepositorySampleData();
            var specials = repo.GetAllSpecials().ToList();

            Assert.AreEqual(3, specials.Count);
            Assert.AreEqual(3, specials[2].SpecialId);
            Assert.AreEqual("Third Special", specials[2].SpecialTitle);
            Assert.AreEqual("Special3 Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vestibulum magna arcu, congue sit amet mattis quis, molestie a sem.  Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vestibulum magna arcu, congue sit amet mattis quis, molestie a sem.  Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vestibulum magna arcu, congue sit amet mattis quis, molestie a sem.", specials[2].SpecialDescription);
        }

        [Test]
        public static void SampleDataCanAddAndDeleteSpecial()
        {
            Specials specialToAdd = new Specials();
            var repo = new SpecialsRepositorySampleData();

            specialToAdd.SpecialTitle = "Fourth Special";
            specialToAdd.SpecialDescription = "Special4 Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vestibulum magna arcu, congue sit amet mattis quis, molestie a sem. ";

            repo.AddSpecial(specialToAdd);
            var specials = repo.GetAllSpecials().ToList();
            var special = repo.GetSpecialById(4);

            Assert.IsNotNull(special);
            Assert.AreEqual(4, specials.Count);

            Assert.AreEqual(4, specials[3].SpecialId);
            Assert.AreEqual("Fourth Special", specials[3].SpecialTitle);
            Assert.AreEqual("Special4 Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vestibulum magna arcu, congue sit amet mattis quis, molestie a sem. ", specials[3].SpecialDescription);
        
            repo.DeleteSpecial(4);

            specials = repo.GetAllSpecials().ToList();
            special = repo.GetSpecialById(4);

            Assert.IsNull(special);
            Assert.AreEqual(3, specials.Count);
        }

        [Test]
        public static void SampleDataCanGetSpecial()
        {
            var repo = new SpecialsRepositorySampleData();
            repo.GetSpecialById(2);

            var specials = repo.GetAllSpecials().ToList();
            Assert.AreEqual(3, specials.Count);
            Assert.AreEqual(3, specials[2].SpecialId);
            Assert.AreEqual("Third Special", specials[2].SpecialTitle);
            Assert.AreEqual("Special3 Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vestibulum magna arcu, congue sit amet mattis quis, molestie a sem.  Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vestibulum magna arcu, congue sit amet mattis quis, molestie a sem.  Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vestibulum magna arcu, congue sit amet mattis quis, molestie a sem.", specials[2].SpecialDescription);
        }

        [Test]
        public void SampleDataCanLoadTransmissions()
        {
            var repo = new TransmissionsRepositorySampleData();

            var transmissions = repo.GetAllTransmissions();

            Assert.AreEqual(2, transmissions.Count);
            Assert.AreEqual(1, transmissions[0].TransmissionId);
            Assert.AreEqual("Automatic", transmissions[0].TransmissionDescription);
        }

        [Test]
        public void SampleDataCanLoadFinancing()
        {
            var repo = new FinancingRepositorySampleData();

            var financing = repo.GetAllFinancing();

            Assert.AreEqual(3, financing.Count);
            Assert.AreEqual(1, financing[0].FinancingId);
            Assert.AreEqual("Bank Finance", financing[0].FinancingDescription);
        }

        [Test]
        public void SampleDataCanLoadVehicleTypes()
        {
            var repo = new VehicleTypesRepositorySampleData();

            var vehicleTypes = repo.GetAllVehicleTypes();

            Assert.AreEqual(2, vehicleTypes.Count);
            Assert.AreEqual(2, vehicleTypes[1].VehicleTypeId);
            Assert.AreEqual("Used", vehicleTypes[1].VehicleTypeDescription);
        }

        [Test]
        public void SampleDataCanLoadBodyStyles()
        {
            var repo = new BodyStylesRepositorySampleData();

            var bodyStyles = repo.GetAllBodyStyles();

            Assert.AreEqual(4, bodyStyles.Count);
            Assert.AreEqual(3, bodyStyles[2].BodyStyleId);
            Assert.AreEqual("Truck", bodyStyles[2].BodyStyleDescription);
        }

        [Test]
        public void SampleDataCanLoadBodyColors()
        {
            var repo = new BodyColorsRepositorySampleData();

            var bodyColors = repo.GetAllBodyColors();

            Assert.AreEqual(5, bodyColors.Count);
            Assert.AreEqual(5, bodyColors[4].BodyColorId);
            Assert.AreEqual("White", bodyColors[4].BodyColorDescription);
        }

        [Test]
        public void SampleDataCanLoadInteriorColors()
        {
            var repo = new InteriorColorsRepositorySampleData();

            var interiorColors = repo.GetAllInteriorColors();

            Assert.AreEqual(5, interiorColors.Count);
            Assert.AreEqual(4, interiorColors[3].InteriorColorId);
            Assert.AreEqual("Light Gray", interiorColors[3].InteriorColorDescription);
        }

        [Test]
        public void SampleDataCanLoadStates()
        {
            var repo = new StatesRepositorySampleData();

            var states = repo.GetAllStates();

            Assert.AreEqual(3, states.Count);
            Assert.AreEqual("MO", states[2].StateId);
            Assert.AreEqual("Missouri", states[2].StateName);
        }

        [Test]
        public void SampleDataCanGetAllContacts()
        {
            var repo = new ContactUsRepositorySampleData();

            var contacts = repo.GetAllContactRequests();

            Assert.AreEqual(2, contacts.Count);
            Assert.AreEqual(2, contacts[1].ContactUsId);
            Assert.AreEqual("John", contacts[1].ContactUsFirstName);
            Assert.AreEqual("Smith", contacts[1].ContactUsLastName);
            Assert.AreEqual("johnsmith@test2.com", contacts[1].ContactUsEmail);
            Assert.AreEqual("222-222-2222", contacts[1].ContactUsPhone);
            Assert.AreEqual("Test2 Lorem ipsum dolor sit amet, consectetur adipiscing elit.", contacts[1].ContactUsMessage);
        }

        [Test]
        public static void SampleDataCanAddContact()
        {
            ContactUs contactToAdd = new ContactUs();
            var repo = new ContactUsRepositorySampleData();

            contactToAdd.ContactUsFirstName = "Sally";
            contactToAdd.ContactUsLastName = "Rogers";
            contactToAdd.ContactUsEmail = "sallyrogers@test3.com";
            contactToAdd.ContactUsPhone = "333-333-3333";
            contactToAdd.ContactUsMessage = "Test3 Lorem ipsum dolor sit amet, consectetur adipiscing elit.";

            repo.AddContact(contactToAdd);
            var contacts = repo.GetAllContactRequests().ToList();

            Assert.IsNotNull(contacts[2]);
            Assert.AreEqual(3, contacts.Count);

            Assert.AreEqual(3, contacts[2].ContactUsId);
            Assert.AreEqual("Sally", contacts[2].ContactUsFirstName);
            Assert.AreEqual("Rogers", contacts[2].ContactUsLastName);
            Assert.AreEqual("sallyrogers@test3.com", contacts[2].ContactUsEmail);
            Assert.AreEqual("333-333-3333", contacts[2].ContactUsPhone);
            Assert.AreEqual("Test3 Lorem ipsum dolor sit amet, consectetur adipiscing elit.", contacts[2].ContactUsMessage);

            repo.DeleteContact(3);
        }

        [Test]
        public void SampleDataCanLoadMakes()
        {
            var repo = new MakesRepositorySampleData();

            var makes = repo.GetAllMakes().ToList();

            Assert.AreEqual(3, makes.Count);
            Assert.AreEqual(1, makes[0].MakeId);
            Assert.AreEqual("placeholder@test.com", makes[0].UserName);
            Assert.AreEqual("Chevrolet", makes[0].MakeDescription);
            Assert.AreEqual(DateTime.Parse("07/22/2018 00.00.00 AM", System.Globalization.CultureInfo.InvariantCulture), makes[0].MakeDateAdded);
        }

        [Test]
        public static void SampleDataCanAddMake()
        {
            Makes makeToAdd = new Makes();
            var repo = new MakesRepositorySampleData();

            makeToAdd.UserId = "00000000-0000-0000-0000-000000000000";
            makeToAdd.MakeDescription = "FakeMake";
            makeToAdd.MakeDateAdded = DateTime.Parse("07/22/2018 00.00.00 AM", System.Globalization.CultureInfo.InvariantCulture);

            repo.AddMake(makeToAdd);
            var makes = repo.GetAllMakes().ToList();

            Assert.IsNotNull(makes[3]);
            Assert.AreEqual(4, makes.Count);

            Assert.AreEqual(4, makes[3].MakeId);
            Assert.AreEqual("placeholder@test.com", makes[3].UserName);
            Assert.AreEqual("FakeMake", makes[3].MakeDescription);
            Assert.AreEqual(DateTime.Parse("07/22/2018 00.00.00 AM", System.Globalization.CultureInfo.InvariantCulture), makes[3].MakeDateAdded);

            repo.DeleteMake(4);
        }

        [Test]
        public void SampleCanGetMakeForModel()
        {
            var repo = new MakesRepositorySampleData();

            var make = repo.GetMakeForModel(7);

            Assert.AreEqual(2, make.MakeId);
            Assert.AreEqual("00000000-0000-0000-0000-000000000000", make.UserId);
            Assert.AreEqual("Ford", make.MakeDescription);
            Assert.AreEqual(DateTime.Parse("07/22/2018 00.00.00 AM", System.Globalization.CultureInfo.InvariantCulture), make.MakeDateAdded);
        }

        [Test]
        public void SampleDataCanLoadCustomers()
        {
            var repo = new CustomersRepositorySampleData();

            var customers = repo.GetAllCustomers();

            Assert.AreEqual(4, customers.Count);
            Assert.AreEqual(2, customers[1].CustomerId);
            Assert.AreEqual("MO", customers[1].StateId);
            Assert.AreEqual("Joe", customers[1].CustomerFirstName);
            Assert.AreEqual("Baker", customers[1].CustomerLastName);
            Assert.AreEqual("222-222-2222", customers[1].CustomerPhone);
            Assert.AreEqual("joebaker@customertest2.com", customers[1].CustomerEmail);
            Assert.AreEqual("Test2 Street1", customers[1].CustomerStreet1);
            Assert.AreEqual("Test2 Street2", customers[1].CustomerStreet2);
            Assert.AreEqual("Test2City", customers[1].CustomerCity);
            Assert.AreEqual("22222", customers[1].CustomerZipCode);
        }

        [Test]
        public static void SampleDataCanAddCustomer()
        {
            Customers customerToAdd = new Customers();
            var repo = new CustomersRepositorySampleData();

            customerToAdd.StateId = "IL";
            customerToAdd.CustomerFirstName = "Sally";
            customerToAdd.CustomerLastName = "Rogers";
            customerToAdd.CustomerPhone = "333-333-3333";
            customerToAdd.CustomerEmail = "sallyrogers @test3.com";
            customerToAdd.CustomerStreet1 = "Test3 Street1";
            customerToAdd.CustomerStreet2 = "";
            customerToAdd.CustomerCity = "Test 3 City";
            customerToAdd.CustomerZipCode = "33333";


            repo.AddCustomer(customerToAdd);
            var customers = repo.GetAllCustomers().ToList();

            Assert.IsNotNull(customers[4]);
            Assert.AreEqual(5, customers.Count);

            Assert.AreEqual(5, customers[4].CustomerId);
            Assert.AreEqual("IL", customers[4].StateId);
            Assert.AreEqual("Sally", customers[4].CustomerFirstName);
            Assert.AreEqual("Rogers", customers[4].CustomerLastName);
            Assert.AreEqual("333-333-3333", customers[4].CustomerPhone);
            Assert.AreEqual("sallyrogers @test3.com", customers[4].CustomerEmail);
            Assert.AreEqual("Test3 Street1", customers[4].CustomerStreet1);
            Assert.AreEqual("", customers[4].CustomerStreet2);
            Assert.AreEqual("Test 3 City", customers[4].CustomerCity);
            Assert.AreEqual("33333", customers[4].CustomerZipCode);

            repo.DeleteCustomer(5);
        }

        [Test]
        public void SampleDataCanGetAllModels()
        {
            var repo = new ModelsRepositorySampleData();

            var models = repo.GetAllModels().ToList();

            Assert.AreEqual(11, models.Count);
            Assert.AreEqual(8, models[7].ModelId);
            Assert.AreEqual(2, models[7].MakeId);
            Assert.AreEqual("placeholder@test.com", models[7].UserName);
            Assert.AreEqual("Transit Connect", models[7].ModelDescription);
            Assert.AreEqual(DateTime.Parse("07/23/2018 00.00.00 AM", System.Globalization.CultureInfo.InvariantCulture), models[7].ModelDateAdded);
        }

        [Test]
        public void SampleDataCanGetModelsForMake()
        {
            var repo = new ModelsRepositorySampleData();

            var models = repo.GetModelsForMake(3).ToList();

            Assert.AreEqual(3, models.Count);
            Assert.AreEqual(10, models[1].ModelId);
            Assert.AreEqual(3, models[1].MakeId);
            Assert.AreEqual("placeholder@test.com", models[1].UserName);
            Assert.AreEqual("MKZ", models[1].ModelDescription);
            Assert.AreEqual(DateTime.Parse("07/23/2018 00.00.00 AM", System.Globalization.CultureInfo.InvariantCulture), models[1].ModelDateAdded);
        }

        [Test]
        public static void SampleDataCanAddModel()
        {
            Models.Tables.Models modelToAdd = new Models.Tables.Models();
            var repo = new ModelsRepositorySampleData ();

            modelToAdd.MakeId = 1;
            modelToAdd.UserId = "00000000-0000-0000-0000-000000000000";
            modelToAdd.ModelDescription = "Impala";
            modelToAdd.ModelDateAdded = DateTime.Parse("07/23/2018 00.00.00 AM", System.Globalization.CultureInfo.InvariantCulture);

            repo.AddModel(modelToAdd);
            var models = repo.GetAllModels().ToList();

            Assert.IsNotNull(models[11]);
            Assert.AreEqual(12, models.Count);

            Assert.AreEqual(12, models[11].ModelId);
            Assert.AreEqual(1, models[11].MakeId);
            Assert.AreEqual("placeholder@test.com", models[11].UserName);
            Assert.AreEqual("Impala", models[11].ModelDescription);
            Assert.AreEqual(DateTime.Parse("07/23/2018 00.00.00 AM", System.Globalization.CultureInfo.InvariantCulture), models[10].ModelDateAdded);

            repo.DeleteModel(12);
        }

        [Test]
        public void SampleDataCanLoadVehicle()
        {
            var repo = new VehiclesRepositorySampleData();

            var vehicle = repo.SelectVehicle(2);

            Assert.IsNotNull(vehicle);
            Assert.AreEqual(2, vehicle.VehicleId);
            Assert.AreEqual(6, vehicle.ModelId);
            Assert.AreEqual(2, vehicle.VehicleTypeId);
            Assert.AreEqual(3, vehicle.BodyStyleId);
            Assert.AreEqual(2, vehicle.BodyColorId);
            Assert.AreEqual(4, vehicle.InteriorColorId);
            Assert.AreEqual(2, vehicle.TransmissionId);
            Assert.AreEqual(2016, vehicle.VehicleYear);
            Assert.AreEqual(50000, vehicle.VehicleMileage);
            Assert.AreEqual("22222222222222222", vehicle.VehicleVIN);
            Assert.AreEqual(14000M, vehicle.VehicleMSRP);
            Assert.AreEqual(13500M, vehicle.VehicleSalesPrice);
            Assert.AreEqual("Test2 Lorem ipsum dolor sit amet, consectetur adipiscing elit.", vehicle.VehicleDescription);
            Assert.AreEqual("inventory-2.PNG", vehicle.VehiclePicture);
            Assert.AreEqual(false, vehicle.VehicleIsFeatured);
        }

        [Test]
        public void SampleDataNotFoundVehicleReturnsNull()
        {
            var repo = new VehiclesRepositorySampleData();

            var vehicle = repo.SelectVehicle(100009);

            Assert.IsNull(vehicle);
        }

        [Test]
        public static void SampleDataCanAddVehicle()
        {
            Vehicles vehicleToAdd = new Vehicles();
            var repo = new VehiclesRepositorySampleData();

            vehicleToAdd.ModelId = 9;
            vehicleToAdd.VehicleTypeId = 1;
            vehicleToAdd.BodyStyleId = 1;
            vehicleToAdd.BodyColorId = 1;
            vehicleToAdd.InteriorColorId = 5;
            vehicleToAdd.TransmissionId = 1;
            vehicleToAdd.VehicleYear = 2018;
            vehicleToAdd.VehicleMileage = 4;
            vehicleToAdd.VehicleVIN = "22222222222222222";
            vehicleToAdd.VehicleMSRP = 46000M;
            vehicleToAdd.VehicleSalesPrice = 44000M;
            vehicleToAdd.VehicleDescription = "Test2 Lorem ipsum dolor sit amet, consectetur adipiscing elit.";
            vehicleToAdd.VehiclePicture = "placeholder.PNG";
            vehicleToAdd.VehicleIsFeatured = true;

            repo.AddVehicle(vehicleToAdd);
            var vehicle = repo.SelectVehicle(100009);

            Assert.IsNotNull(vehicle);

            Assert.AreEqual(100009, vehicle.VehicleId);
            Assert.AreEqual(9, vehicle.ModelId);
            Assert.AreEqual(1, vehicle.VehicleTypeId);
            Assert.AreEqual(1, vehicle.BodyStyleId);
            Assert.AreEqual(1, vehicle.BodyColorId);
            Assert.AreEqual(5, vehicle.InteriorColorId);
            Assert.AreEqual(1, vehicle.TransmissionId);
            Assert.AreEqual(2018, vehicle.VehicleYear);
            Assert.AreEqual(4, vehicle.VehicleMileage);
            Assert.AreEqual("22222222222222222", vehicle.VehicleVIN);
            Assert.AreEqual(46000M, vehicle.VehicleMSRP);
            Assert.AreEqual(44000M, vehicle.VehicleSalesPrice);
            Assert.AreEqual("Test2 Lorem ipsum dolor sit amet, consectetur adipiscing elit.", vehicle.VehicleDescription);
            Assert.AreEqual("placeholder.PNG", vehicle.VehiclePicture);
            Assert.AreEqual(true, vehicle.VehicleIsFeatured);
        }

        [Test]
        public static void SampleDataCanEditVehicle()
        {
            Vehicles vehicleToAdd = new Vehicles();
            var repo = new VehiclesRepositorySampleData();

            var next = repo.GetNextVehicleId();

            vehicleToAdd.ModelId = 9;
            vehicleToAdd.VehicleTypeId = 1;
            vehicleToAdd.BodyStyleId = 1;
            vehicleToAdd.BodyColorId = 1;
            vehicleToAdd.InteriorColorId = 5;
            vehicleToAdd.TransmissionId = 1;
            vehicleToAdd.VehicleYear = 2018;
            vehicleToAdd.VehicleMileage = 4;
            vehicleToAdd.VehicleVIN = "22222222222222222";
            vehicleToAdd.VehicleMSRP = 46000M;
            vehicleToAdd.VehicleSalesPrice = 44000M;
            vehicleToAdd.VehicleDescription = "Test2 Lorem ipsum dolor sit amet, consectetur adipiscing elit.";
            vehicleToAdd.VehiclePicture = "placeholder.PNG";
            vehicleToAdd.VehicleIsFeatured = true;

            repo.AddVehicle(vehicleToAdd);

            vehicleToAdd.ModelId = 8;
            vehicleToAdd.VehicleTypeId = 2;
            vehicleToAdd.BodyStyleId = 4;
            vehicleToAdd.BodyColorId = 2;
            vehicleToAdd.InteriorColorId = 2;
            vehicleToAdd.TransmissionId = 2;
            vehicleToAdd.VehicleYear = 2017;
            vehicleToAdd.VehicleMileage = 8000;
            vehicleToAdd.VehicleVIN = "33333333333333333";
            vehicleToAdd.VehicleMSRP = 23000M;
            vehicleToAdd.VehicleSalesPrice = 21000M;
            vehicleToAdd.VehicleDescription = "Test3 Lorem ipsum dolor sit amet, consectetur adipiscing elit.";
            vehicleToAdd.VehiclePicture = "placeholder3.PNG";
            vehicleToAdd.VehicleIsFeatured = false;

            repo.UpdateVehicle(vehicleToAdd);

            var vehicle = repo.SelectVehicle(next);

            Assert.IsNotNull(vehicle);

            Assert.AreEqual(next, vehicle.VehicleId);
            Assert.AreEqual(8, vehicle.ModelId);
            Assert.AreEqual(2, vehicle.VehicleTypeId);
            Assert.AreEqual(4, vehicle.BodyStyleId);
            Assert.AreEqual(2, vehicle.BodyColorId);
            Assert.AreEqual(2, vehicle.InteriorColorId);
            Assert.AreEqual(2, vehicle.TransmissionId);
            Assert.AreEqual(2017, vehicle.VehicleYear);
            Assert.AreEqual(8000, vehicle.VehicleMileage);
            Assert.AreEqual("33333333333333333", vehicle.VehicleVIN);
            Assert.AreEqual(23000M, vehicle.VehicleMSRP);
            Assert.AreEqual(21000M, vehicle.VehicleSalesPrice);
            Assert.AreEqual("Test3 Lorem ipsum dolor sit amet, consectetur adipiscing elit.", vehicle.VehicleDescription);
            Assert.AreEqual("placeholder3.PNG", vehicle.VehiclePicture);
            Assert.AreEqual(false, vehicle.VehicleIsFeatured);
        }

        [Test]
        public static void SampleDataCanDeleteVehicle()
        {
            Vehicles vehicleToAdd = new Vehicles();
            var repo = new VehiclesRepositorySampleData();

            vehicleToAdd.ModelId = 9;
            vehicleToAdd.VehicleTypeId = 1;
            vehicleToAdd.BodyStyleId = 1;
            vehicleToAdd.BodyColorId = 1;
            vehicleToAdd.InteriorColorId = 5;
            vehicleToAdd.TransmissionId = 1;
            vehicleToAdd.VehicleYear = 2018;
            vehicleToAdd.VehicleMileage = 4;
            vehicleToAdd.VehicleVIN = "22222222222222222";
            vehicleToAdd.VehicleMSRP = 46000M;
            vehicleToAdd.VehicleSalesPrice = 44000M;
            vehicleToAdd.VehicleDescription = "Test2 Lorem ipsum dolor sit amet, consectetur adipiscing elit.";
            vehicleToAdd.VehiclePicture = "placeholder.PNG";
            vehicleToAdd.VehicleIsFeatured = true;

            repo.AddVehicle(vehicleToAdd);
            var vehicle = repo.SelectVehicle(100009);

            Assert.IsNotNull(vehicle);

            repo.DeleteVehicle(100009);
            vehicle = repo.SelectVehicle(100009);

            Assert.IsNull(vehicle);
        }

        [Test]
        public void SampleDataGetFeaturedVehicles()
        {
            var repo = new InventoryRepositorySampleData();

            var vehicles = repo.GetFeaturedVehicles().ToList();

            Assert.AreEqual(6, vehicles.Count());
            Assert.AreEqual(6, vehicles[3].VehicleId);
            Assert.AreEqual(2016, vehicles[3].VehicleYear);
            Assert.AreEqual("Chevrolet", vehicles[3].MakeDescription);
            Assert.AreEqual("Express", vehicles[3].ModelDescription);
            Assert.AreEqual(15000M, vehicles[3].VehicleSalesPrice);
            Assert.AreEqual("inventory-6.PNG", vehicles[3].VehiclePicture);
        }

        [Test]
        public void SampleDataCanGetVehicleDetails()
        {
            var repo = new InventoryRepositorySampleData();

            var vehicle = repo.GetVehicleDetails(12);

            Assert.IsNotNull(vehicle);
            Assert.AreEqual(2016, vehicle.VehicleYear);
            Assert.AreEqual("Ford", vehicle.MakeDescription);
            Assert.AreEqual("Transit Connect", vehicle.ModelDescription);
            Assert.AreEqual("Van", vehicle.BodyStyleDescription);
            Assert.AreEqual("Light Gray", vehicle.InteriorColorDescription);
            Assert.AreEqual("Manual", vehicle.TransmissionDescription);
            Assert.AreEqual(50000, vehicle.VehicleMileage);
            Assert.AreEqual("Silver", vehicle.BodyColorDescription);
            Assert.AreEqual("12111111111111111", vehicle.VehicleVIN);
            Assert.AreEqual(14500M, vehicle.VehicleSalesPrice);
            Assert.AreEqual(15000M, vehicle.VehicleMSRP);
            Assert.AreEqual("inventory-12.PNG", vehicle.VehiclePicture);
            Assert.AreEqual("Test12 Lorem ipsum dolor sit amet, consectetur adipiscing elit.", vehicle.VehicleDescription);
        }

        [Test]
        public void SampleDataCanSearchInventoryNoParams()
        {
            var repo = new InventoryRepositorySampleData();
            var found = repo.SearchInventory(new VehicleSearchParameters { });

            Assert.AreEqual(20, found.Count());
        }

        [Test]
        public void SampleDataCanSearchInventoryAllParams()
        {
            var repo = new InventoryRepositorySampleData();
            var found = repo.SearchInventory(new VehicleSearchParameters { NewUsed = "Used", MakeModelYear = "T", MinPrice = 20000, MaxPrice = 80000, MinYear = 2010, MaxYear = 2016 });

            Assert.AreEqual(2, found.Count());
        }

        [Test]
        public void SampleDataCanSearchInventoryFiveParams()
        {
            var repo = new InventoryRepositorySampleData();
            var found = repo.SearchInventory(new VehicleSearchParameters { NewUsed = "Used", MakeModelYear = "E", MinPrice = 30000, MaxPrice = 80000, MinYear = 2010 });
            Assert.AreEqual(1, found.Count());

            found = repo.SearchInventory(new VehicleSearchParameters { NewUsed = "Used", MinPrice = 30000, MaxPrice = 80000, MinYear = 2010, MaxYear = 2015 });
            Assert.AreEqual(3, found.Count());

            found = repo.SearchInventory(new VehicleSearchParameters { NewUsed = "Used", MakeModelYear = "E", MaxPrice = 60000, MinYear = 2010, MaxYear = 2016 });
            Assert.AreEqual(1, found.Count());

            found = repo.SearchInventory(new VehicleSearchParameters { MakeModelYear = "Navigator", MinPrice = 30000, MaxPrice = 40000, MinYear = 2018, MaxYear = 2018 });
            Assert.AreEqual(2, found.Count());
        }

        [Test]
        public void SampleDataCanSearchInventoryFourParams()
        {
            var repo = new InventoryRepositorySampleData();
            var found = repo.SearchInventory(new VehicleSearchParameters { NewUsed = "Used", MakeModelYear = "C", MinPrice = 20000, MaxPrice = 50000 });
            Assert.AreEqual(6, found.Count());

            found = repo.SearchInventory(new VehicleSearchParameters { NewUsed = "Used", MinPrice = 10000, MaxPrice = 30000, MinYear = 2012 });
            Assert.AreEqual(6, found.Count());

            found = repo.SearchInventory(new VehicleSearchParameters { NewUsed = "Used", MaxPrice = 30000, MinYear = 2012, MaxYear = 2018 });
            Assert.AreEqual(6, found.Count());

            found = repo.SearchInventory(new VehicleSearchParameters { NewUsed = "Used", MakeModelYear = "C", MaxPrice = 20000, MinYear = 2016 });
            Assert.AreEqual(1, found.Count());

            found = repo.SearchInventory(new VehicleSearchParameters { NewUsed = "Used", MakeModelYear = "C", MinYear = 2011, MaxYear = 2015 });
            Assert.AreEqual(4, found.Count());

            found = repo.SearchInventory(new VehicleSearchParameters { NewUsed = "Used", MinPrice = 20000, MinYear = 2011, MaxYear = 2013 });
            Assert.AreEqual(2, found.Count());

            found = repo.SearchInventory(new VehicleSearchParameters { MakeModelYear = "Navigator", MinPrice = 20000, MaxPrice = 40000, MinYear = 2018 });
            Assert.AreEqual(2, found.Count());

            found = repo.SearchInventory(new VehicleSearchParameters { MakeModelYear = "Navigator", MinPrice = 20000, MinYear = 2018, MaxYear = 2018 });
            Assert.AreEqual(2, found.Count());

            found = repo.SearchInventory(new VehicleSearchParameters { MakeModelYear = "Navigator", MinPrice = 10000, MinYear = 2017, MaxYear = 2018 });
            Assert.AreEqual(2, found.Count());

            found = repo.SearchInventory(new VehicleSearchParameters { MinPrice = 30000, MaxPrice = 40000, MinYear = 2010, MaxYear = 2018 });
            Assert.AreEqual(4, found.Count());
        }

        [Test]
        public void SampleDataCanSearchInventoryThreeParams()
        {
            var repo = new InventoryRepositorySampleData();
            var found = repo.SearchInventory(new VehicleSearchParameters { NewUsed = "Used", MakeModelYear = "C", MinPrice = 20000 });
            Assert.AreEqual(10, found.Count());

            found = repo.SearchInventory(new VehicleSearchParameters { NewUsed = "Used", MinPrice = 10000, MaxPrice = 30000 });
            Assert.AreEqual(11, found.Count());

            found = repo.SearchInventory(new VehicleSearchParameters { NewUsed = "Used", MaxPrice = 30000, MinYear = 2012 });
            Assert.AreEqual(6, found.Count());

            found = repo.SearchInventory(new VehicleSearchParameters { NewUsed = "Used", MaxPrice = 30000, MaxYear = 2012 });
            Assert.AreEqual(8, found.Count());

            found = repo.SearchInventory(new VehicleSearchParameters { NewUsed = "Used", MakeModelYear = "C", MaxYear = 2015 });
            Assert.AreEqual(11, found.Count());

            found = repo.SearchInventory(new VehicleSearchParameters { NewUsed = "Used", MinPrice = 10000, MaxYear = 2010 });
            Assert.AreEqual(11, found.Count());

            found = repo.SearchInventory(new VehicleSearchParameters { NewUsed = "Used", MinYear = 2005, MaxYear = 2010 });
            Assert.AreEqual(7, found.Count());

            found = repo.SearchInventory(new VehicleSearchParameters { MakeModelYear = "C", MaxPrice = 30000, MinYear = 2012 });
            Assert.AreEqual(4, found.Count());

            found = repo.SearchInventory(new VehicleSearchParameters { MakeModelYear = "C", MinYear = 2005, MaxYear = 2010 });
            Assert.AreEqual(1, found.Count());

            found = repo.SearchInventory(new VehicleSearchParameters { MakeModelYear = "Navigator", MaxPrice = 10000, MaxYear = 2018 });
            Assert.AreEqual(0, found.Count());

            found = repo.SearchInventory(new VehicleSearchParameters { NewUsed = "Used", MinPrice = 20000, MaxYear = 2010 });
            Assert.AreEqual(10, found.Count());

            found = repo.SearchInventory(new VehicleSearchParameters { MinPrice = 30000, MinYear = 2008, MaxYear = 2010 });
            Assert.AreEqual(3, found.Count());

            found = repo.SearchInventory(new VehicleSearchParameters { MinPrice = 30000, MaxPrice = 50000, MaxYear = 2010 });
            Assert.AreEqual(2, found.Count());

            found = repo.SearchInventory(new VehicleSearchParameters { MaxPrice = 15000, MinYear = 2010, MaxYear = 2016 });
            Assert.AreEqual(6, found.Count());

            found = repo.SearchInventory(new VehicleSearchParameters { NewUsed = "Used", MakeModelYear = "C", MaxPrice = 20000 });
            Assert.AreEqual(3, found.Count());

            found = repo.SearchInventory(new VehicleSearchParameters { NewUsed = "Used", MakeModelYear = "C", MinYear = 2011 });
            Assert.AreEqual(6, found.Count());

            found = repo.SearchInventory(new VehicleSearchParameters { NewUsed = "Used", MinPrice = 20000, MinYear = 2011 });
            Assert.AreEqual(8, found.Count());

            found = repo.SearchInventory(new VehicleSearchParameters { MakeModelYear = "Navigator", MinPrice = 20000, MaxPrice = 40000 });
            Assert.AreEqual(2, found.Count());

            found = repo.SearchInventory(new VehicleSearchParameters { MakeModelYear = "Navigator", MinPrice = 20000, MinYear = 2018 });
            Assert.AreEqual(2, found.Count());

            found = repo.SearchInventory(new VehicleSearchParameters { MinPrice = 30000, MaxPrice = 40000, MinYear = 2010 });
            Assert.AreEqual(4, found.Count());
        }

        [Test]
        public void SampleDataCanSearchInventoryTwoParams()
        {
            var repo = new InventoryRepositorySampleData();
            var found = repo.SearchInventory(new VehicleSearchParameters { NewUsed = "New", MakeModelYear = "2017" });
            Assert.AreEqual(1, found.Count());

            found = repo.SearchInventory(new VehicleSearchParameters { NewUsed = "New", MinPrice = 20000 });
            Assert.AreEqual(5, found.Count());

            found = repo.SearchInventory(new VehicleSearchParameters { NewUsed = "Used", MaxPrice = 34000 });
            Assert.AreEqual(13, found.Count());

            found = repo.SearchInventory(new VehicleSearchParameters { NewUsed = "Used", MinYear = 2005 });
            Assert.AreEqual(20, found.Count());

            found = repo.SearchInventory(new VehicleSearchParameters { NewUsed = "Used", MaxYear = 2005 });
            Assert.AreEqual(7, found.Count());

            found = repo.SearchInventory(new VehicleSearchParameters { MakeModelYear = "C", MinPrice = 30000 });
            Assert.AreEqual(7, found.Count());

            found = repo.SearchInventory(new VehicleSearchParameters { MakeModelYear = "C", MaxPrice = 30000 });
            Assert.AreEqual(9, found.Count());

            found = repo.SearchInventory(new VehicleSearchParameters { MakeModelYear = "C", MinYear = 2010 });
            Assert.AreEqual(9, found.Count());

            found = repo.SearchInventory(new VehicleSearchParameters { MakeModelYear = "C", MaxYear = 2010 });
            Assert.AreEqual(7, found.Count());

            found = repo.SearchInventory(new VehicleSearchParameters { MinYear = 2005, MaxYear = 2016 });
            Assert.AreEqual(19, found.Count());

            found = repo.SearchInventory(new VehicleSearchParameters { MinPrice = 30000, MaxPrice = 50000 });
            Assert.AreEqual(9, found.Count());

            found = repo.SearchInventory(new VehicleSearchParameters { MinPrice = 30000, MinYear = 2010 });
            Assert.AreEqual(11, found.Count());

            found = repo.SearchInventory(new VehicleSearchParameters { MinPrice = 30000, MaxYear = 2010 });
            Assert.AreEqual(7, found.Count());

            found = repo.SearchInventory(new VehicleSearchParameters { MaxPrice = 30000, MinYear = 2010 });
            Assert.AreEqual(9, found.Count());

            found = repo.SearchInventory(new VehicleSearchParameters { MaxPrice = 30000, MaxYear = 2010 });
            Assert.AreEqual(6, found.Count());
        }

        [Test]
        public void SampleDataCanSearchInventoryOneParam()
        {
            var repo = new InventoryRepositorySampleData();

            var found = repo.SearchInventory(new VehicleSearchParameters { NewUsed = "New" });
            Assert.AreEqual(6, found.Count());

            found = repo.SearchInventory(new VehicleSearchParameters { MakeModelYear = "2017" });
            Assert.AreEqual(2, found.Count());

            found = repo.SearchInventory(new VehicleSearchParameters { MakeModelYear = "C" });
            Assert.AreEqual(16, found.Count());

            found = repo.SearchInventory(new VehicleSearchParameters { MinPrice = 30000 });
            Assert.AreEqual(18, found.Count());

            found = repo.SearchInventory(new VehicleSearchParameters { MaxPrice = 35000 });
            Assert.AreEqual(17, found.Count());

            found = repo.SearchInventory(new VehicleSearchParameters { MinYear = 2017 });
            Assert.AreEqual(7, found.Count());

            found = repo.SearchInventory(new VehicleSearchParameters { MaxYear = 2009 });
            Assert.AreEqual(12, found.Count());
        }

        [Test]
        public void SampleDataCanSearchSalesForReportNoParams()
        {
            var repo = new SalesRepositorySampleData();
            var report = repo.GetSalesForReport(new SalesReportSearchParameters { }).ToList();

            Assert.AreEqual(235000M, report[0].TotalSales);
            Assert.AreEqual(5, report[0].TotalVehicles);
        }

        [Test]
        public void SampleDataCanSearchSalesForReportAllParams()
        {
            var repo = new SalesRepositorySampleData();
            var report = repo.GetSalesForReport(new SalesReportSearchParameters { ToDate = "12/31/2017", FromDate = "1-1-2017", UserId = "33333333-3333-3333-3333-333333333333" }).ToList();

            Assert.AreEqual(30000M, report[0].TotalSales);
            Assert.AreEqual(1, report[0].TotalVehicles);
        }

        [Test]
        public void SampleDataCanSearchSalesForReportOneParameter()
        {
            var repo = new SalesRepositorySampleData();
            var report = repo.GetSalesForReport(new SalesReportSearchParameters { UserId = "22222222-2222-2222-2222-222222222222" }).ToList();

            Assert.AreEqual(110000M, report[0].TotalSales);
            Assert.AreEqual(4, report[0].TotalVehicles);

            report = repo.GetSalesForReport(new SalesReportSearchParameters { FromDate = "04/01/2018" }).ToList();

            Assert.AreEqual(133900.51M, report[0].TotalSales);
            Assert.AreEqual(5, report[0].TotalVehicles);

            report = repo.GetSalesForReport(new SalesReportSearchParameters { ToDate = "04/01/2018" }).ToList();

            Assert.AreEqual(132000M, report[0].TotalSales);
            Assert.AreEqual(3, report[0].TotalVehicles);
        }

        [Test]
        public void SampleDataCanSearchSalesForReportForTwoParameters()
        {
            var repo = new SalesRepositorySampleData();
            var report = repo.GetSalesForReport(new SalesReportSearchParameters { ToDate = "05/1/2018", UserId = "11111111-1111-1111-1111-111111111111" }).ToList();

            Assert.AreEqual(10500M, report[0].TotalSales);
            Assert.AreEqual(1, report[0].TotalVehicles);

            report = repo.GetSalesForReport(new SalesReportSearchParameters { FromDate = "05/1/2018", UserId = "11111111-1111-1111-1111-111111111111" }).ToList();

            Assert.AreEqual(123400.51M, report[0].TotalSales);
            Assert.AreEqual(4, report[0].TotalVehicles);

            report = repo.GetSalesForReport(new SalesReportSearchParameters { ToDate = "06/30/2018", FromDate = "5-1-2018" }).ToList();

            Assert.AreEqual(99500M, report[0].TotalSales);
            Assert.AreEqual(2, report[0].TotalVehicles);
        }

        [Test]
        public void SampleDataCanSearchSalesForReportReturnNullList()
        {
            var repo = new SalesRepositorySampleData();
            var report = repo.GetSalesForReport(new SalesReportSearchParameters { ToDate = "12/1/2017" }).ToList();

            Assert.AreEqual(0, report.Count());
        }

        [Test]
        public void SampleDataCanSearchSalesForReportBogusDate()
        {
            var repo = new SalesRepositorySampleData();
            var report = repo.GetSalesForReport(new SalesReportSearchParameters { ToDate = "bbbb", FromDate = "mmmm" }).ToList();

            Assert.AreEqual(235000M, report[0].TotalSales);
            Assert.AreEqual(5, report[0].TotalVehicles);
        }

        [Test]
        public void SampleDataCanCheckIsSold()
        {
            var repo = new InventoryRepositorySampleData();

            var sold = repo.IsSold(100000);
            Assert.IsTrue(sold);

            sold = repo.IsSold(14);
            Assert.IsFalse(sold);
        }

        [Test]
        public static void SampleDataCanAddSale()
        {
            Sales saleToAdd = new Sales();
            var repo = new SalesRepositorySampleData();

            saleToAdd.CustomerId = 1;
            saleToAdd.VehicleId = 25;
            saleToAdd.FinancingId = 1;
            saleToAdd.UserId = "11111111-1111-1111-1111-111111111111";
            saleToAdd.SaleAmount = 7400.51M;
            saleToAdd.SaleDate = DateTime.Parse("07/23/2018 00.00.00 AM", System.Globalization.CultureInfo.InvariantCulture);

            repo.AddSale(saleToAdd);
            var sales = repo.GetAllSales().ToList();

            Assert.IsNotNull(sales[13]);
            Assert.AreEqual(14, sales.Count);

            Assert.AreEqual(14, sales[13].SaleId);
            Assert.AreEqual(1, sales[13].CustomerId);
            Assert.AreEqual(25, sales[13].VehicleId);
            Assert.AreEqual(1, sales[13].FinancingId);
            Assert.AreEqual("11111111-1111-1111-1111-111111111111", sales[13].UserId);
            Assert.AreEqual(7400.51, sales[13].SaleAmount);
            Assert.AreEqual(DateTime.Parse("07/23/2018 00.00.00 AM", System.Globalization.CultureInfo.InvariantCulture), sales[13].SaleDate);
        }

        [Test]
        public void SampleDataCanGetRoles()
        {
            var repo = new UsersRepositorySampleData();

            var roles = repo.GetAllRoles().ToList();

            Assert.AreEqual(3, roles.Count);
        }

        [Test]
        public static void SampleDataCanGetRole()
        {
            var repo = new UsersRepositorySampleData();
            repo.GetRoleNameForId("cbe2009c-472f-4739-830f-d87368ec6ca4");

            var roles = repo.GetAllRoles().ToList();
            Assert.AreEqual(3, roles.Count);
            Assert.AreEqual("cbe2009c-472f-4739-830f-d87368ec6ca4", roles[1].Id);
            Assert.AreEqual("Sales", roles[1].Name);
            Assert.AreEqual("AppRole", roles[1].Discriminator);
        }

        [Test]
        public void SampleDataCanGetUserById()
        {
            var repo = new UsersRepositorySampleData();

            var user = repo.GetUserById("33333333-3333-3333-3333-333333333333");

            Assert.AreEqual("33333333-3333-3333-3333-333333333333", user.UserId);
            Assert.AreEqual("Test", user.FirstName);
            Assert.AreEqual("Salesuser3", user.LastName);
            Assert.AreEqual("testsalesuser3@test.com", user.Email);
            Assert.AreEqual("Sales", user.Role);
            Assert.AreEqual("cbe2009c-472f-4739-830f-d87368ec6ca4", user.RoleId);
        }
    }
}

