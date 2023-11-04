FROM postgres:14.7-alpine

EXPOSE 15432

COPY sqlscripts/ /docker-entrypoint-initdb.d/
# docker build -t marketplace-db:v1 -f sqlscripts/Dockerfile .
