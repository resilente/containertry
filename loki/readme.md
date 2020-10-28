```
docker-compose -f loki-compose.yaml up -d
```

En la configuracion del DataSource de Grafana agregar Loki con la siguiente URL:
```
http://loki:3100
```
Con **localhost** no funciona. Funciona con el nombre de la red **loki**.
