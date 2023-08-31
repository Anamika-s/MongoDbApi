using MongoDB.Driver;
using MongoDbApi.Models;

namespace MongoDbApi
{
    public class EmployeeService
    {
        private readonly IMongoCollection<Employee> _employees;
        public EmployeeService(IEmployeeDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _employees = database.GetCollection<Employee>(settings.EmployeesCollectionName);

        }

        public List<Employee> Get()
        {
            List<Employee> employees;
            employees = _employees.Find(emp => true).ToList();
            return employees;
        }

        public Employee Get(string id) =>
            _employees.Find<Employee>(emp => emp.Id == id).FirstOrDefault();

        public void Post(Employee employee) =>
           _employees.InsertOne(employee);


        public void Edit(int id, Employee employee) =>
           _employees.ReplaceOne(n => n.Id.Equals(id), employee, new UpdateOptions { IsUpsert = true });

    

    public void Delete(int id) =>
         _employees.DeleteOne<Employee>(x=>x.Equals(id));


    }
}

