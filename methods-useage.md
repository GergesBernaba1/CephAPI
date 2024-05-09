# Methods Useage

#### Method: `chromePlugin`

**Description**

The `chromePlugin` method processes a job posting received through a Chrome plugin. It reads the incoming job data (expected to be in JSON format), associates it with the authenticated user, and stores it in the job service. Additionally, it retrieves the user's resume, updates it to include the new job, and triggers relevant resume adjustments using the resume service.

**Endpoint**

* **HTTP Method**: `POST`
* **Route**: `/api/job/chromeplugin`

**Authorization**

The endpoint is protected with the `[Authorize("ApiKeyOrToken")]` attribute. Users must authenticate with either an API key or a valid user token.

**Request**

* **Content Type**: `application/json`
* **Body Example**:

```json
jsonCopy code{
  "jobTitle": "Front-End Developer",
  "company": "Innovative Tech Co.",
  "jobDescription": "Develop user interfaces with modern JavaScript frameworks.",
  "jobLocation": "Remote",
  "applicationStatus": "Applied",
  "appliedDate": "2024-05-09T09:45:00Z",
  "userId": "user123"
}
```

**Response**

* **Status Code**: `200 OK`
  * **Description**: Successful processing of the job data. Returns the added LinkedIn job data.
  * **Body Example**:

```json
{
  "jobId": 125,
  "jobTitle": "Front-End Developer",
  "company": "Innovative Tech Co.",
  "jobDescription": "Develop user interfaces with modern JavaScript frameworks.",
  "jobLocation": "Remote",
  "applicationStatus": "Applied",
  "appliedDate": "2024-05-09T09:45:00Z",
  "userId": "user123"
}
```

**Error Handling**

* **`400 Bad Request`**: If the incoming job data is not in a valid format or cannot be deserialized properly, the method returns an empty `Ok` response.
* **`500 Internal Server Error`**: An error occurred on the server while processing the request.

#### Method: `UserRegistration`

**Description**

The `UserRegistration` method links a candidate's resume to a job posting by its ID. It retrieves the user's default resume based on their authenticated email and matches it with the job data. If both resume and job exist, it rewrites the resume experience with the relevant job data using a Chrome plugin and returns the new CV ID.

**Endpoint**

* **HTTP Method**: `POST`
* **Route**: `/api/job/{id}/resume`

**Parameters**

* **Path Parameter**:
  * `id` (int): The unique identifier of the job to be associated with the resume.

**Request**

No specific request body is required; all necessary information is derived from the path parameter and the authenticated user's context.

**Response**

*   **Status Code**: `200 OK`

    * **Description**: Successfully associated the job with the resume and rewrote the resume.
    * **Body Example**:

    ```json
    {
      "newCvId": 456
    }
    ```
*   **Status Code**: `400 Bad Request`

    * **Description**: Invalid job or resume data, meaning either the job or resume could not be found or associated.
    * **Body Example**:

    ```json
    {
      "error": "Invalid job or resume"
    }
    ```

**Error Handling**

* **`400 Bad Request`**: Triggered if either the job or resume cannot be found for the given job ID.
* **`500 Internal Server Error`**: An unexpected error occurred while processing the request.

#### Method: `PostCoverLetter`

**Description**

The `PostCoverLetter` method generates a cover letter specific to a job application. It retrieves the default resume of the authenticated user based on their email and matches it with the job data identified by the given `id`. If both resume and job data are valid, it generates a tailored cover letter using the `ResumeService`.

**Endpoint**

* **HTTP Method**: `POST`
* **Route**: `/api/job/{id}/coverletter`

**Parameters**

* **Path Parameter**:
  * `id` (int): The unique identifier of the job for which the cover letter is being generated.

**Request**

No specific request body is required since all necessary information is derived from the path parameter and the authenticated user's context.

**Response**

*   **Status Code**: `200 OK`

    * **Description**: Successfully created a cover letter for the specified job.
    * **Body Example**:

    ```json
    {
      "createdDate": "2024-05-09T09:45:00Z"
    }
    ```
*   **Status Code**: `400 Bad Request`

    * **Description**: Either the job or resume could not be found.
    * **Body Example**:

    ```json
    {
      "error": "Invalid job or resume"
    }
    ```

**Error Handling**

* **`400 Bad Request`**: Triggered if either the job or resume could not be found for the given job ID.
* **`500 Internal Server Error`**: An unexpected error occurred while processing the request.

#### Method: `PostEmail`

**Description**

The `PostEmail` method generates an email specific to a job application. It retrieves the authenticated user's default resume based on their email and matches it with the job data identified by the provided `id`. If both the resume and job data are valid, the method uses `ResumeService` to compose a customized email.

**Endpoint**

* **HTTP Method**: `POST`
* **Route**: `/api/job/{id}/email`

**Parameters**

* **Path Parameter**:
  * `id` (int): The unique identifier of the job for which the email is being generated.

**Request**

No request body is required as the relevant data is gathered from the path parameter and the authenticated user's context.

**Response**

*   **Status Code**: `200 OK`

    * **Description**: Successfully generated an email for the specified job.
    * **Body Example**:

    ```json
    {
      "createdDate": "2024-05-09T09:45:00Z"
    }
    ```
*   **Status Code**: `400 Bad Request`

    * **Description**: Invalid job or resume data, meaning either the job or resume could not be found or associated.
    * **Body Example**:

    ```json
    {
      "error": "Invalid job or resume"
    }
    ```

**Error Handling**

* **`400 Bad Request`**: Triggered if the job or resume cannot be found for the given job ID.
* **`500 Internal Server Error`**: An unexpected error occurred while processing the request.

#### Method: `PostInterviewQuestions`

**Description**

The `PostInterviewQuestions` method generates interview questions tailored to a specific job application. It retrieves the authenticated user's default resume based on their email and pairs it with the job data identified by the `id` parameter. If both resume and job data are valid, the method employs the `ResumeService` to generate interview questions.

**Endpoint**

* **HTTP Method**: `POST`
* **Route**: `/api/job/{id}/interviewquestions`

**Parameters**

* **Path Parameter**:
  * `id` (int): The unique identifier of the job for which interview questions are to be generated.

**Request**

No request body is required, as all necessary information is derived from the path parameter and the authenticated user's context.

**Response**

*   **Status Code**: `200 OK`

    * **Description**: Successfully generated interview questions for the specified job.
    * **Body Example**:

    ```json
    {
      "createdDate": "2024-05-09T09:45:00Z"
    }
    ```
*   **Status Code**: `400 Bad Request`

    * **Description**: The request is invalid due to missing or incorrect data (e.g., job or resume could not be found).
    * **Body Example**:

    ```json
    {
      "error": "Invalid job or resume"
    }
    ```

**Error Handling**

* **`400 Bad Request`**: Triggered if either the job or resume cannot be found for the given job ID.
* **`500 Internal Server Error`**: An unexpected error occurred while processing the request.

#### &#x20;Method: `GetCoverLetter`

**Description**

Retrieves the cover letter associated with a job application based on its unique identifier. If no cover letter is found for the given job ID, it returns a default cover letter body.

**Endpoint**

* **HTTP Method**: `GET`
* **Route**: `/api/job/{id}/coverletter`

**Parameters**

* **Path Parameter**:
  * `id` (int): The unique identifier of the job for which the cover letter is being retrieved.

**Response**

*   **Status Code**: `200 OK`

    * **Description**: Returns the cover letter body associated with the specified job.
    * **Body Example**:

    ```json
    {
      "coverLetterBody": "some cover letter body.123"
    }
    ```
* **Status Code**: `404 Not Found`
  * **Description**: No cover letter exists for the specified job.

#### Method: `GetEmail`

**Description**

Retrieves the email message associated with a job application based on its unique identifier. If no email is found, it returns a default message.

**Endpoint**

* **HTTP Method**: `GET`
* **Route**: `/api/job/{id}/email`

**Parameters**

* **Path Parameter**:
  * `id` (int): The unique identifier of the job for which the email is being retrieved.

**Response**

*   **Status Code**: `200 OK`

    * **Description**: Returns the email message associated with the specified job.
    * **Body Example**:

    ```json
    {
      "body": "some email body.123",
      "subject": "some email subject.",
      "id": 10
    }
    ```
* **Status Code**: `404 Not Found`
  * **Description**: No email exists for the specified job.

#### Method: `GetInterviewQuestions`

**Description**

Retrieves the interview questions associated with a job application by its unique identifier. If no questions are found, it returns default interview questions.

**Endpoint**

* **HTTP Method**: `GET`
* **Route**: `/api/job/{id}/interviewquestions`

**Parameters**

* **Path Parameter**:
  * `id` (int): The unique identifier of the job for which interview questions are being retrieved.

**Response**

*   **Status Code**: `200 OK`

    * **Description**: Returns the interview questions associated with the specified job.
    * **Body Example**:

    ```json
    {
      "questionText": "some interview question.123"
    }
    ```
* **Status Code**: `404 Not Found`
  * **Description**: No interview questions exist for the specified job.

#### Method: `GetResume`

**Description**

Retrieves the resume associated with a job application based on its unique identifier. If the authenticated user is an admin, it provides additional screening information. If the user is not an admin, it only returns data for the job matching the authenticated user's context.

**Endpoint**

* **HTTP Method**: `GET`
* **Route**: `/api/job/{id}/resume`

**Parameters**

* **Path Parameter**:
  * `id` (int): The unique identifier of the job for which the resume is being retrieved.

**Response**

*   **Status Code**: `200 OK`

    * **Description**: Returns the resume information associated with the specified job.
    * **Body Example (Admin)**:

    ```json
    {
      "cv": {
        "resumeId": 456,
        "name": "John Doe",
        "skills": ["C#", ".NET", "Azure"]
      },
      "screen": {
        "screeningStatus": "Passed",
        "notes": "Candidate is suitable."
      }
    }
    ```

    * **Body Example (Non-Admin)**:

    ```json
    {
      "cv": {
        "resumeId": 456,
        "name": "John Doe",
        "skills": ["C#", ".NET", "Azure"]
      },
      "screen": "{}"
    }
    ```
* **Status Code**: `404 Not Found`
  * **Description**: No resume data exists for the specified job.

#### &#x20;Method: `GetCoverLetter`

**Description**

Retrieves the cover letter associated with a job application based on its unique identifier. If no cover letter is found for the given job ID, it returns a default cover letter body.

**Endpoint**

* **HTTP Method**: `GET`
* **Route**: `/api/job/{id}/coverletter`

**Parameters**

* **Path Parameter**:
  * `id` (int): The unique identifier of the job for which the cover letter is being retrieved.

**Response**

*   **Status Code**: `200 OK`

    * **Description**: Returns the cover letter body associated with the specified job.
    * **Body Example**:

    ```json
    jsonCopy code{
      "coverLetterBody": "some cover letter body.123"
    }
    ```
* **Status Code**: `404 Not Found`
  * **Description**: No cover letter exists for the specified job.

#### Method: `GetEmail`

**Description**

Retrieves the email message associated with a job application based on its unique identifier. If no email is found, it returns a default message.

**Endpoint**

* **HTTP Method**: `GET`
* **Route**: `/api/job/{id}/email`

**Parameters**

* **Path Parameter**:
  * `id` (int): The unique identifier of the job for which the email is being retrieved.

**Response**

*   **Status Code**: `200 OK`

    * **Description**: Returns the email message associated with the specified job.
    * **Body Example**:

    ```json
    jsonCopy code{
      "body": "some email body.123",
      "subject": "some email subject.",
      "id": 10
    }
    ```
* **Status Code**: `404 Not Found`
  * **Description**: No email exists for the specified job.

#### Method: `GetInterviewQuestions`

**Description**

Retrieves the interview questions associated with a job application by its unique identifier. If no questions are found, it returns default interview questions.

**Endpoint**

* **HTTP Method**: `GET`
* **Route**: `/api/job/{id}/interviewquestions`

**Parameters**

* **Path Parameter**:
  * `id` (int): The unique identifier of the job for which interview questions are being retrieved.

**Response**

*   **Status Code**: `200 OK`

    * **Description**: Returns the interview questions associated with the specified job.
    * **Body Example**:

    ```json
    jsonCopy code{
      "questionText": "some interview question.123"
    }
    ```
* **Status Code**: `404 Not Found`
  * **Description**: No interview questions exist for the specified job.

#### Method: `GetResume`

**Description**

Retrieves the resume associated with a job application based on its unique identifier. If the authenticated user is an admin, it provides additional screening information. If the user is not an admin, it only returns data for the job matching the authenticated user's context.

**Endpoint**

* **HTTP Method**: `GET`
* **Route**: `/api/job/{id}/resume`

**Parameters**

* **Path Parameter**:
  * `id` (int): The unique identifier of the job for which the resume is being retrieved.

**Response**

*   **Status Code**: `200 OK`

    * **Description**: Returns the resume information associated with the specified job.
    * **Body Example (Admin)**:

    ```json
    {
      "cv": {
        "resumeId": 456,
        "name": "John Doe",
        "skills": ["C#", ".NET", "Azure"]
      },
      "screen": {
        "screeningStatus": "Passed",
        "notes": "Candidate is suitable."
      }
    }
    ```

    * **Body Example (Non-Admin)**:

    ```json
    {
      "cv": {
        "resumeId": 456,
        "name": "John Doe",
        "skills": ["C#", ".NET", "Azure"]
      },
      "screen": "{}"
    }
    ```
* **Status Code**: `404 Not Found`
  * **Description**: No resume data exists for the specified job.
