# Available Methods

#### Endpoints

**GET `/api/job`**

* **Method**: `GetAllJobs()`
* **Description**: Retrieves all job listings associated with the authenticated user's ID and email.



**POST `/api/job/chromeplugin`**

* **Method**: `chromePlugin()`
* **Description**: Processes job data received from a Chrome plugin, adds the job to the user's profile, and updates the user's resume with the new job information.



**POST `/api/job/{id}/resume`**

* **Method**: `UserRegistration(int id)`
* **Description**: Registers or updates the default resume with a new job entry specified by its ID.
* **Authorization**: Requires API key or token.
* **Return Type**: `IActionResult`
* **Returns**: An `Ok` response with the new CV's ID or a `BadRequest` if the operation fails.

**Various Endpoints for Individual Documents**

* **Methods**: `PostCoverLetter`, `PostEmail`, `PostInterviewQuestions`
* **Description**: These methods handle the generation of cover letters, emails, and interview questions for specific job applications.

**GET Endpoints for Retrieving Documents**

* **Methods**: `GetCoverLetter`, `GetEmail`, `GetInterviewQuestions`, `GetResume`
* **Description**: Retrieve previously stored documents related to specific jobs, such as cover letters, emails, interview questions, or resumes.

