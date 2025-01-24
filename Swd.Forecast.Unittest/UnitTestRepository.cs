using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.EnvironmentVariables;
using Serilog;
using Swd.Forecast.Model;
using Swd.Forecast.Repository;
using System.Reflection;

namespace Swd.Forecast.Unittest
{
    public class UnitTestRepository
    {
        private  IConfiguration _configuration;
        private  string _appConfigFile = "appSettings.json";

        private TypeOfRecommendationRepository _repository;
        private TypeOfMeasuredDataRepository _repositoryTypeOfMeasuredData;
        private MeasuredDataRepository _repositoryMeasuredData;


        [SetUp]
        public void Setup()
        {
            _configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile(_appConfigFile, optional: true, reloadOnChange: true)
                .Build();

            Log.Logger = new LoggerConfiguration()
                   .ReadFrom.Configuration(_configuration)
                   .CreateLogger();
            Log.Debug(string.Format("{0}: Logging started", MethodBase.GetCurrentMethod().Name));
            
            _repository = new TypeOfRecommendationRepository();
            _repositoryTypeOfMeasuredData = new TypeOfMeasuredDataRepository();
            _repositoryMeasuredData = new MeasuredDataRepository();
        }


        #region Testmethods TypeOfRecommendation
        [Test]
        public void TypeOfRecommendation_Add()
        {
            TypeOfRecommendation item = GetTypeOfRecommendation();

            _repository.Add(item);

            TypeOfRecommendation addedItem = _repository.ReadByKey(item.Id);
            Assert.IsNotNull(addedItem);
        }

        [Test]
        public async Task TypeOfRecommendation_AddAsync()
        {
            TypeOfRecommendation item = GetTypeOfRecommendation();

            await _repository.AddAsync(item);

            TypeOfRecommendation addedItem = await _repository.ReadByKeyAsync(item.Id);
            Assert.IsNotNull(addedItem);
        }

        [Test]
        public void TypeOfRecommendation_Delete()
        {

            TypeOfRecommendation item = GetTypeOfRecommendation();

            _repository.Add(item);

            _repository.Delete(item.Id);

            TypeOfRecommendation addedItem = _repository.ReadByKey(item.Id);
            Assert.IsNull(addedItem);

        }

        [Test]
        public async Task TypeOfRecommendation_DeleteAsync()
        {
            TypeOfRecommendation item = GetTypeOfRecommendation();

            await _repository.AddAsync(item);

            await _repository.AsyncDelete(item.Id);

            TypeOfRecommendation addedItem = await _repository.ReadByKeyAsync(item.Id);
            Assert.IsNull(addedItem);
        }

        [Test]
        public void TypeOfRecommendation_Update()
        {
            TypeOfRecommendation item = GetTypeOfRecommendation();
            
            _repository.Add(item);
            _repository.Update(item, item.Id);

            TypeOfRecommendation addedItem = _repository.ReadByKey(item.Id);
            Assert.AreNotEqual(null, addedItem.CreatedBy);
        }

        [Test]
        public async Task TypeOfRecommendation_UpdateAsync()
        {
            TypeOfRecommendation item = GetTypeOfRecommendation();

            await _repository.AddAsync(item);
            await _repository.UpdateAsync(item, item.Id);

            TypeOfRecommendation addedItem = await _repository.ReadByKeyAsync(item.Id);
            Assert.AreNotEqual(null, addedItem.CreatedBy);
        }

        [Test]
        public void TypeOfRecommendation_SelectAll()
        {
            TypeOfRecommendationRepository repository = new TypeOfRecommendationRepository();

            TypeOfRecommendation item = GetTypeOfRecommendation();

            _repository.Add(item);

            //Variante ohne ToList()
            //Schneller, da nur ein Wert vom Server übertragen wird
            //Zählen findet am Server statt
            int numberOfItems = _repository.ReadAll().Count();

            //Variante mit ToList()
            //Langsamer, da alle Objekte vom Server übertragen werden
            //Zählen findet am Client statt
            List<TypeOfRecommendation> itemList = _repository.ReadAll().ToList();

            int numberOfItems2 = _repository.ReadAll().ToList().Count();

            Assert.AreNotEqual(0, itemList.Count);  

        }

        [Test]
        public async Task TypeOfRecommendation_SelectAllAsync()
        {
            TypeOfRecommendation item = GetTypeOfRecommendation();

            await _repository.AddAsync(item);

            //Variante ohne ToList()
            //Schneller, da nur ein Wert vom Server übertragen wird
            //Zählen findet am Server statt
            int numberOfItems = _repository.ReadAll().Count();

            //Variante mit ToList()
            //Langsamer, da alle Objekte vom Server übertragen werden
            //Zählen findet am Client statt
            List<TypeOfRecommendation> itemList = await _repository.ReadAll().ToListAsync();

            int numberOfItems2 = _repository.ReadAll().ToList().Count();

            Assert.AreNotEqual(0, itemList.Count);
        }
        #endregion


        #region Testmethods TypeOfMeasuredData
        [Test]
        public void TypeOfMeasuredData_Add()
        {
            TypeOfMeasuredData item = GetTypeOfMeasuredData();

            _repositoryTypeOfMeasuredData.Add(item);

            TypeOfMeasuredData addedItem = _repositoryTypeOfMeasuredData.ReadByKey(item.Id);
            Assert.IsNotNull(addedItem);
        }
        #endregion


        #region Testmethods MeasuredData
        [Test]
        public async Task MeasuredData_AddAsync()
        {
            MeasuredData item = GetMeasuredData();

            await _repositoryMeasuredData.AddAsync(item);
            Assert.AreNotEqual(0, item.Id);
        }

        [Test]
        public async Task MeasuredData__UpdateAsync()
        {
            MeasuredData item = GetMeasuredData();

            await _repositoryMeasuredData.AddAsync(item);
            await _repositoryMeasuredData.UpdateAsync(item, item.Id);

            MeasuredData addedItem = await _repositoryMeasuredData.ReadByKeyAsync(item.Id);
            Assert.AreNotEqual(null, addedItem.CreatedBy);
        }

        [Test]
        public async Task MeasuredData_DeleteAsync()
        {
            MeasuredData item = GetMeasuredData();

            await _repositoryMeasuredData.AddAsync(item);

            await _repositoryMeasuredData.AsyncDelete(item.Id);

            MeasuredData addedItem = await _repositoryMeasuredData.ReadByKeyAsync(item.Id);
            Assert.IsNull(addedItem);
        }

        [Test]
        public async Task MeasuredData_SelectAllAsync()
        {
            MeasuredData item = GetMeasuredData();

            await _repositoryMeasuredData.AddAsync(item);

            int numberOfItems = _repositoryMeasuredData.ReadAll().Count();

            Assert.AreNotEqual(0, numberOfItems);
        }
        #endregion


        #region Methods Objectcreation
        private TypeOfRecommendation GetTypeOfRecommendation()
        {
            TypeOfRecommendation item = new TypeOfRecommendation();
            string id = string.Format("Testitem_{0}", DateTime.Now.ToString());
            item.Id = id;
            return item;
        }

        private TypeOfMeasuredData GetTypeOfMeasuredData()
        {
            TypeOfMeasuredData item = new TypeOfMeasuredData();
            string id = string.Format("Testitem_{0}", DateTime.Now.ToString());
            item.Id = id;
            return item;
        }

        private MeasuredData GetMeasuredData()
        {
            MeasuredData item = new MeasuredData();
            item.MeasuredDateTime = DateTime.Now;
            item.MeasuredValue = Math.Round(new Random().NextDouble()* 99, 2).ToString();
            return item;
        }
        #endregion
    }
}