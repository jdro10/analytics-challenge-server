# Analytics Challenge Server

### Project setup

```sh
git clone https://github.com/jdro10/analytics-challenge-server.git

# IMPORTANT: Update API settings:
cd analytics-challenge

# Update appsettings.json file
"ApiSettings": {
  "ApiUrl": "https://{DOMAIN}/api/public/v1", // Replace {DOMAIN} with the actual API domain.
  "ApiKey": "API_KEY_HERE"
}

# Back into the root folder:
cd ..

# Run docker compose:
docker-compose up -d --build

# Application will be running in the following host and port:
http://localhost:7070/
```
