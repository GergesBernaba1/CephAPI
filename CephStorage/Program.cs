using Amazon.S3;
using Amazon.S3.Model;
using Amazon.S3.Transfer;
using Microsoft.VisualBasic;
using System;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;


namespace CephStorage
{
    internal class Program
    {
      
        static async Task Main(string[] args)
        {

            // Console.WriteLine("Hello World!");
            //IConfiguration configuration = new ConfigurationBuilder()
            //.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
            //.Build();

            //var endpoint = configuration["Ceph:Endpoint"];
            //var accessKey = configuration["Ceph:AccessKey"];
            //var secretKey = configuration["Ceph:SecretKey"];
            //var bucketName = configuration["Ceph:BucketName"];

            //  var endpoint = "https://192.168.2.240:8000";
          //  var endpoint = "https://ceph.expertapps.com.sa";
            var endpoint = "https://ceph.expertapps.com.sa:8000";
            var accessKey = "KJODXTFEDZCI5K7FP3Y1";
            var secretKey = "pD0vEANBayBeMPvFhybppeKTkGH8XrgKjLllzsrw";
            var bucketName = "bucket01";



            // Ceph cluster configuration
            //string clusterName = "ceph";
            //string userName = "client.admin";
            //string keyring = "/etc/ceph/ceph.client.admin.keyring";

            //// Connection to the Ceph cluster
            //var cluster = new Cluster(clusterName, userName, keyring);

            //// Ceph pool and object name
            //string poolName = "my-pool";
            //string objectName = "file.txt";

            //// Local file path to upload
            //string filePath = "C:\\path\\to\\file.txt";

            //// Read the file content
            //byte[] fileContent = File.ReadAllBytes(filePath);

            //// Upload the file content to the Ceph object store
            //using (var ioCtx = cluster.CreateIoCtx(poolName))
            //{
            //    ioCtx.WriteFull(objectName, fileContent);
            //}

            //Console.WriteLine("File uploaded successfully.");



            AmazonS3Config config = new AmazonS3Config();
            config.ServiceURL = endpoint;

            AmazonS3Client s3Client = new AmazonS3Client(
                    accessKey,
                    secretKey,
                    config
                    );
            var filePath = "D:/settings.txt";





            //PutBucketRequest request = new PutBucketRequest();
            //request.BucketName = "bucket02";
            //var res = await s3Client.PutBucketAsync(request);
            //if (res.HttpStatusCode == HttpStatusCode.OK)
            //{
            //    Console.WriteLine($"{res.HttpStatusCode},the bucket was successfully created");
            //    Console.ReadLine();
            //}
            //else
            //{
            //    Console.WriteLine("there was an error creating the bucket");
            //    Console.ReadLine();

            //}

            //ListBucketsResponse response = await s3Client.ListBucketsAsync();
            //foreach (S3Bucket b in response.Buckets)
            //{
            //    Console.WriteLine("{0}\t{1}", b.BucketName, b.CreationDate);
            //    Console.ReadLine();

            //}

            //using (var fileStream = new FileStream(filePath, FileMode.Open))
            //{
            //    var s3Requ = new Amazon.S3.Model.PutObjectRequest
            //    {
            //        BucketName = bucketName,
            //        Key = filePath,
            //        InputStream = fileStream,
            //        AutoCloseStream = false,
            //    };
            //    var s3Resp = await s3Client.PutObjectAsync(s3Requ);
            //    if (s3Resp.HttpStatusCode == HttpStatusCode.OK)
            //    {

            //            Console.WriteLine("the object was successfully uploaded");
            //            Console.ReadLine();
            //    }
            //    else
            //    {

            //        Console.WriteLine("there was an error uploading the object");
            //        Console.ReadLine();
            //    }
            //}



            //PutObjectRequest request = new PutObjectRequest();
            //request.BucketName = bucketName;
            //request.Key = "settings.txt";
            //request.ContentType = "text/plain";
            //request.FilePath =filePath;

            //TransferUtility fileTransferUtility = new TransferUtility(s3Client);
            //await fileTransferUtility.UploadAsync(filePath, bucketName, "settings.txt");

            //var res =await s3Client.PutObjectAsync(request);
            //if (res.HttpStatusCode == HttpStatusCode.OK)
            //{

            //    Console.WriteLine("the object was successfully uploaded");
            //    Console.ReadLine();
            //}
            //else
            //{

            //    Console.WriteLine("there was an error uploading the object");
            //    Console.ReadLine();
            //}

            //This for accept any ssl
            //ServicePointManager.ServerCertificateValidationCallback = (sender, cert, chain, errors) => true;


            //// var response = await s3Client.PutObjectAsync(request);
            //PutACLRequest request2 = new PutACLRequest();
            //request.CannedACL = S3CannedACL.PublicRead;
            //s3Client.PutACLAsync(request2);

            //if (response.HttpStatusCode == HttpStatusCode.OK || response.HttpStatusCode == HttpStatusCode.Created)
            //{
            //    Console.WriteLine("Object uploaded.");
            //}
            //else
            //{
            //    Console.WriteLine($"Error uploading object: {response.HttpStatusCode}");
            //}

            //PutACLRequest request2 = new PutACLRequest();
            //request2.BucketName = bucketName;
            //request2.Key = "hello.txt";
            //request2.CannedACL = S3CannedACL.PublicRead;
            //s3Client.PutACLAsync(request2);

            //PutACLRequest request3 = new PutACLRequest();
            //request3.BucketName = bucketName;
            //request3.Key = "secret_plans.txt";
            //request3.CannedACL = S3CannedACL.Private;
            //s3Client.PutACLAsync(request3);


            //ListObjectsRequest request4 = new ListObjectsRequest();
            //request4.BucketName = bucketName; // set the bucket name
            //ListObjectsResponse response = await s3Client.ListObjectsAsync(request4);
            //foreach (S3Object o in response.S3Objects)
            //{
            //    Console.WriteLine("{0}\t{1}\t{2}", o.Key, o.Size, o.LastModified);
            //    Console.ReadLine();
            //}

            //////////////
            var objectName = "settings";
            var objectContent = "Hello, Ceph!";
            //  var filePath = "D:/settings.txt";
            //  // // Upload an object
            //  // Console.WriteLine($"Uploading object {objectName} to bucket {bucketName}...");
           await UploadObjectAsync(s3Client, bucketName, objectName, objectContent);
            //   await UploadObjectAsync(s3Client, bucketName, objectName, filePath);
            //   Console.WriteLine($"Object {objectName} uploaded.");

            //// Download an object
            //Console.WriteLine($"Downloading object {objectName} from bucket {bucketName}...");
            //var downloadedContent = await DownloadObjectAsync(s3Client, bucketName, objectName);
            //Console.WriteLine($"Object {objectName} downloaded. Content: {downloadedContent}");

            //// Delete an object
            //Console.WriteLine($"Deleting object {objectName} from bucket {bucketName}...");
            //await DeleteObjectAsync(s3Client, bucketName, objectName);
            //Console.WriteLine($"Object {objectName} deleted.");


            ///////////////////

        }
        static async Task<string> UploadObjectAsync(AmazonS3Client s3Client, string bucketName, string objectName, string objectContent)
        {

            try
            {
                using (var stream = new MemoryStream(Encoding.UTF8.GetBytes(objectContent)))
                {
                    var transferUtility = new TransferUtility(s3Client);
                    await transferUtility.UploadAsync(stream, bucketName, objectName);
                }
                return $"Object '{objectName}' uploaded successfully to bucket '{bucketName}'.";
            }
            catch (AmazonS3Exception s3Exception)
            {
                return $"Error uploading object '{objectName}' to bucket '{bucketName}': {s3Exception.Message}";
            }
        }

        static void UploadFile(Uri fileUrl, Stream s, string BucketName)
        {
            if (fileUrl == null)
            {
                throw new ArgumentNullException(nameof(fileUrl), "The file URL cannot be null.");
            }

            var filePath = fileUrl.AbsolutePath;
            // We need to strip off any leading '/' in the path or
            // else it creates a path with an empty leading segment
            if (filePath.StartsWith("/"))
                filePath = filePath.Substring(1);

            using (var s3 = new Amazon.S3.AmazonS3Client(
         "KJODXTFEDZCI5K7FP3Y1", "pD0vEANBayBeMPvFhybppeKTkGH8XrgKjLllzsrw", awsSessionToken: ""))
            {
                var s3Requ = new Amazon.S3.Model.PutObjectRequest
                {
                    BucketName = BucketName,
                    Key = filePath,
                    InputStream = s,
                    AutoCloseStream = false,
                };
                var s3Resp = s3.PutObjectAsync(s3Requ);
            }
        }

        static async Task<string> UploadObjectAsyncnew(AmazonS3Client s3Client, string bucketName, string objectKey, string filePath)
        {
            try
            {
                var request = new UploadPartRequest
                {
                    BucketName = bucketName,
                    Key = objectKey,
                    FilePath = filePath,
                    PartSize = 5 * 1024 * 1024, // 5 MB
                    PartNumber = 1
                };

                var response = await s3Client.UploadPartAsync(request);

                return $"Object '{objectKey}' uploaded successfully to bucket '{bucketName}'.";
            }
            catch (AmazonS3Exception ex)
            {
                return $"Error uploading object '{objectKey}' to bucket '{bucketName}': {ex.Message}";
            }
        }

        static async Task<string> DownloadObjectAsync(AmazonS3Client s3Client, string bucketName, string objectName)
        {
            var getObjectRequest = new Amazon.S3.Model.GetObjectRequest
            {
                BucketName = bucketName,
                Key = objectName
            };
            using (var response = await s3Client.GetObjectAsync(getObjectRequest))
            using (var streamReader = new StreamReader(response.ResponseStream))
            {
                return streamReader.ReadToEnd();
            }
        }

        static async Task DeleteObjectAsync(AmazonS3Client s3Client, string bucketName, string objectName)
        {
            var deleteObjectRequest = new Amazon.S3.Model.DeleteObjectRequest
            {
                BucketName = bucketName,
                Key = objectName
            };
            await s3Client.DeleteObjectAsync(deleteObjectRequest);
        }

        static async Task ListObjectsInBuckets(AmazonS3Client s3Client, string bucketName)
        {
            ListObjectsV2Request request = new ListObjectsV2Request();
            request.BucketName = bucketName;

            ListObjectsV2Response response = await s3Client.ListObjectsV2Async(request);
            foreach (S3Object o in response.S3Objects)
            {
                Console.WriteLine("{0}\t{1}\t{2}", o.Key, o.Size, o.LastModified);
            }
        }


    }
}
