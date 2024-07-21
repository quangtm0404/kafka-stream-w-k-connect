FROM docker.arvancloud.ir/confluentinc/cp-kafka-connect:latest

RUN confluent-hub install confluentinc/kafka-connect-jdbc:10.7.6 --no-prompt

# Docker file for JDBC to connect to multiple destination of Database systems
# docker build -t docker.arvancloud.ir/confluentinc/cp-kafka-connect:latest .
# Remember to build image with the image name of connect to register jdbc into kafka connect