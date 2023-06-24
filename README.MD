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


### To run Kubernetes deployments/service yaml files
kubectl apply -f platformservice.yaml
(make sure to push the image to DockerHub first)

### To check Kubernetes deployments
kubectl get deployments
### To check Kubernetes pods
kubectl get pods
### To delete Kubernetes deployments
kubectl delete deployments platformservice-deployment
(when you delete containers, kubernetes will auto spin up new ones. This is because of the deployment file)

NodePort allows you to access the service from outside the cluster.
### To get Kubernetes services
kubectl get services