# Kafka Stream Application with Kafka Stream And Kafka Connect


## Note
Create Topic in cli
```bash 
docker exec -it kafka bash
bin/kafka-topics --create --if-not-exists --topic usertopic --replication-factor=1 --partitions=3 --bootstrap-server kafka:9092
```
Create Kafka Stream Steps
```bash
docker exec -it ksqldb-cli2 bash
ksqldb http://ksqldb-server2:8088 
CREATE STREAM mystream (name VARCHAR, favorite_number INTEGER,favorite_color VARCHAR) WITH(kafka_topic='topicname', value_format='avro');
```
after that create topic name with avro serializer and publish into topic