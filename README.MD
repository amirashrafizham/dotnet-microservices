Currently at Kubernetes (2:46:00)

### To build Docker in arm64 [for Mac M1, with Dockerfile]
docker build -t platformservice:latest .   

### To build Docker in amd64 [for Azure Containers, without Dockerfile]
Insert : 
<ContainerImageName>container_registry_name/platformservice</ContainerImageName> in .csproj
dotnet publish --os linux --arch x64 /t:PublishContainer -c Release

### To run Docker
docker run --name platformservice -p 8080:80 -d platformservice:latest 

to run the amd64, use Docker desktop app. Easier.

### To inspect Docker image
docker inspect platformservice 


