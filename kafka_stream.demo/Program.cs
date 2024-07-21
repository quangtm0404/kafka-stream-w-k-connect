
using Confluent.Kafka;
using Confluent.SchemaRegistry;
using Confluent.SchemaRegistry.Serdes;


string bootstrapServers = "127.0.0.1:9194,127.0.0.1:9294,127.0.0.1:9394";
string schemaRegistryUrl = "localhost:8081";
string topicName = "demo";

var producerConfig = new ProducerConfig
{
    BootstrapServers = bootstrapServers,
    SecurityProtocol = SecurityProtocol.SaslPlaintext,
    SaslMechanism = SaslMechanism.Plain,
    SaslUsername = "user3",
    SaslPassword = "password3"
};

var schemaRegistryConfig = new SchemaRegistryConfig
{
    Url = schemaRegistryUrl
};


var avroSerializerConfig = new AvroSerializerConfig
{
    // optional Avro serializer properties:
    BufferBytes = 100,
    AutoRegisterSchemas = true
};

CancellationTokenSource cts = new CancellationTokenSource();

using (var schemaRegistry = new CachedSchemaRegistryClient(schemaRegistryConfig))

using (var producer = new ProducerBuilder<string, User>(producerConfig)
        .SetValueSerializer(new AvroSerializer<User>(schemaRegistry, avroSerializerConfig))
        .Build())
{

    Console.WriteLine($"{producer.Name} producing on {topicName}. Enter user names, q to exit.");

    int i = 1;

    string text;

    while ((text = Console.ReadLine() ?? string.Empty) != "q")
    {
        User user = new User { name = text, favorite_color = "green", favorite_number = ++i };

        await producer.ProduceAsync(topicName, new Message<string, User> { Key = string.Empty, Value = user })
            .ContinueWith(task =>
            {
                if (!task.IsFaulted)
                {
                    Console.WriteLine($"produced to: {task.Result.TopicPartitionOffset}");
                    return;
                }

                Console.WriteLine($"error producing message: {task.Exception.InnerException}");
            });
    }
}

cts.Cancel();

