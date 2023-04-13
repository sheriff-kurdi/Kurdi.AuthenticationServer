add.migration:
	cd Kurdi.AuthenticationService.Api;\
	dotnet ef migrations add $(name) --context AppDbContext -p ../Kurdi.AuthenticationService.Infrastructure/Kurdi.AuthenticationService.Infrastructure.csproj -o Data/Migrations

dorp.migrations:
	rm -rf Kurdi.AuthenticationService.Infrastructure/Data/Migrations

drop.database:
	docker exec -it postgres psql -U postgres -c "DROP DATABASE authentication_service"

update.database:
	cd Kurdi.AuthenticationService.Api; \
	dotnet ef database update  --context AppDbContext -p ../Kurdi.AuthenticationService.Infrastructure/Kurdi.AuthenticationService.Infrastructure.csproj 

test:
	cd Kurdi.AuthenticationService.Test;\
	dotnet test

run:
	cd Kurdi.AuthenticationService.Api;\
	dotnet run

publish2:
	cd Kurdi.AuthenticationService.Api;\
	dotnet publish -c Release -o ../publish -p:PublishReadyToRun=true -p:PublishSingleFile=true -p:PublishTrimmed=true --self-contained true -p:IncludeNativeLibrariesForSelfExtract=true

publish:
	cd Kurdi.AuthenticationService.Api;\
	dotnet publish -c Release -o ../publish -r linux-x64 -p:PublishSingleFile=true --self-contained true


run.published:
	cd publish;\
	./Kurdi.AuthenticationService.Api




docker.postgres.create:
	docker run --rm -d \
		--name postgres \
		-e POSTGRES_USER=postgres \
		-e POSTGRES_PASSWORD=123456789 \
		-e POSTGRES_DB=postgres \
		-v ${HOME}/postgres/data/:/var/lib/postgresql/data \
		-p 5432:5432 \
		postgres
