REDIS

Servidor Redis:

```
    docker run -d --name redis --restart always -p 6379:6379 redis:alpine3.12
    /usr/bin/redis-server
```

Cliente web:
```
    docker run -d --name redis-php-admin -e REDIS_1_HOST=redis --link redis:redis -p 8081:80 erikdubbelboer/phpredisadmin
```

Compose Redis + cliente web
```
    docker-compose -f redis-compose.yaml up -d
```
