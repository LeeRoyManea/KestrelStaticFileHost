# KestrelStaticFileServer

KestrelStaticFileServer is a simple web server for hosting static files. It requires no configuration or security setup, allowing you to quickly expose files over HTTP by overriding the `/app/wwwroot/` path with the directory you want to serve.

## Usage

### Running with Docker

You can easily deploy the KestrelStaticFileServer using Docker. Here's an example of how to do it:

1. **Pull the Docker Image**:

   ```bash
   docker pull leeroymanea/kestrel-static-file-server:latest
   ```

2. **Run the Docker Container**:

   Replace `/path/to/your/static/files` with the directory you want to expose over HTTP.

   ```bash
   docker run -d -p 80:80 -v /path/to/your/static/files:/app/wwwroot/ leeroymanea/kestrel-static-file-server:latest
   ```

   This command will start the KestrelStaticFileServer container, exposing your static files on port 80.

### Running with Docker Compose

You can also use Docker Compose to manage your KestrelStaticFileServer deployment. Here's an example `docker-compose.yml` file:

```yaml
version: '3'
services:
  web:
    image: leeroymanea/kestrel-static-file-server:latest
    ports:
      - "80:80"
    volumes:
      - /path/to/your/static/files:/app/wwwroot/
```

Replace `/path/to/your/static/files` with the directory you want to expose over HTTP.

Then, you can run the following command to start the server:

```bash
docker-compose up -d
```

This will start the KestrelStaticFileServer container in detached mode, exposing your static files on port 80.

## License

This project is licensed under the [GPLv3](LICENSE).

## Support me 

If you want to support me, buy a [Coffee](https://ko-fi.com/leeroy_manea)

Thank you