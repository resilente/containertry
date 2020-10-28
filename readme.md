Borrar todos los contenedores:

```
docker container rm --force $(docker container ls --quiet --all)
```

Borrar todas las imagenes:

```
docker image rm --force $(docker image ls --quiet --all)
```

