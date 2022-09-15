// See https://aka.ms/new-console-template for more information
using Grpc.Net.Client;

Console.WriteLine("Loading client...");

string SERVER_URL = "http://localhost:50051";

using var channel = GrpcChannel.ForAddress(SERVER_URL);
var client = new TodoPackage.TodoService.TodoServiceClient(channel);

var reply = client.createTodo(new TodoPackage.TodoItem { Id = Nanoid.Nanoid.Generate(), Text = Faker.Country.Name() });

Console.WriteLine("New Todo added: " + reply.ToString());
Console.WriteLine();

var todoList = client.readTodos(new TodoPackage.Empty()).Items.ToList();

foreach (var todoItem in todoList)
{
  Console.WriteLine("Todo Item text = " + todoItem.Text);
}

