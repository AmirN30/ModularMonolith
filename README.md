# ModularMonolith

# Run db
cd .\ModularMonolith.Modules.Conferences.Core\
docker-compose up -d
docker ps
docker logs


# Add Migrations
dotnet ef

cd .\ModularMonolith.Modules.Conferences.Core\
dotnet ef migrations add Conferences_Module_init --startup-project ..\..\..\Bootstrapper\ModularMonolith.Bootstrapper -o .\DAL\EF\Migrations --context ConferencesDbContext

cd .\ModularMonolith.Modules.Speakers.Core\
dotnet ef migrations add Speakers_Module_init --startup-project ..\..\..\Bootstrapper\ModularMonolith.Bootstrapper -o .\DAL\EF\Migrations --context SpeakersDbContext
