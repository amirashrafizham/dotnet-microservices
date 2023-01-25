Currently at Docker (2:16:00)

### To build Docker in arm64 [for Mac M1, with Dockerfile]
docker build -t amirashrafizham/platformservice:latest .   

### To build Docker in amd64 [for Azure Containers, without Dockerfile]
Insert : 
<ContainerImageName>amirashrafizham/platformservice</ContainerImageName> in .csproj
dotnet publish --os linux --arch x64 /t:PublishContainer -c Release

### To run Docker
docker run --name amirashrafizham/platformservice -p 8080:80 -d amirashrafizham/platformservice:latest 

to run the amd64, use Docker desktop app. Easier.

### To inspect Docker image
docker inspect amirashrafizham/platformservice 


