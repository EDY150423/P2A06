using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
[ApiController]
[Route ("api/eq")]
public class EqController : Controller {
[HttpGet("listar-pais-origen")]
public IActionResult ListarPaisOrigen(){
//Listar todos los vuelos que hayan salido de Australia.
MongoClient client = new MongoClient(CadenasConexion.Mongo_DB);
var db = client.GetDatabase("Aeropuerto");
var collection = db.GetCollection<Aeropuerto>("Vuelos");
var filtro = Builders<Aeropuerto>.Filter.Eq(x => x.PaisOrigen,"Australia");
var lista = collection.Find(filtro).ToList();
return Ok(lista);

}
}