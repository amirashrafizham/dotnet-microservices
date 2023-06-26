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
kubectl apply -f platforms-depl.yaml
kubectl apply -f platforms-np-srv.yaml
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


[at 3:42:00 of youtube video]
The "async" keyword in C# is still synchronous from a messaging perspective. The client still has to wait for a response. The "async" keyword will hand back it's thread to the thread pool where it can be reused. Synchronous messaging can occur in microservices architecture, however this creates a tight coupling and strong dependency. Imagine Service A has to call Service B. Service B has to call Services C and D. We can't make the client wait for a response. This is resolved by using GRPC or EventBus 


[at 4:30:00 of youtube video]
ClusterIP is a service and will be attached to a container. These IPs will be used as a reference for containers to communicate with each other. Replace "http://localhost:6000/api/" with "http://commands-clusterip-srv:80/api/" or "http://platforms-clusterip-srv:80/api/" i.e. the name of the ClusterIP + Port in the yaml file 

### To restart a deployment + pull the latest docker image
kubectl rollout restart deployment [deployment_name]

# Currently at Adding an API Gateway
