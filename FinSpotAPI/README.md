Create API Docker image:
- navigate to 'FinSpotAPI' folder
- run 'docker build -t finspot-api .'

Create API Docker container:
- run 'docker run -d -p 5100:5100 -p 5101:5101 --name finspot-api finspot-api'

Create Database Docker container:
- run 'docker run -d -p 5432:5432 --name finspot-api.database -e POSTGRES_USER=FinSpot -e POSTGRES_PASSWORD=123456 -e POSTGRES_DB=FinSpot postgres'

Create Env:
- run 'docker-compose up --build'


Add new migration:
- navigate to 'FinSpotAPI.Web' project
- exec 'Add-Migration <migration_name> -Project FinSpotAPI.Domain.Migrations'

Apply migration:
- navigate to 'FinSpotAPI.Web' project
- exec 'Update-Database'
