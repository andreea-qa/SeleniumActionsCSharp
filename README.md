# C-Sharp Selenium Actions  

The Actions class in Selenium C# allows us to perform complex interactions with web elements, such as drag and drop, using modifyer keys, right-clicking or double-clicking.

## Configure Environment Variables

Before the tests are run, please set the environment variables LT_USERNAME & LT_ACCESS_KEY from the terminal. The account details are available on your [LambdaTest Profile](https://accounts.lambdatest.com/detail/profile) page.

For macOS:

```bash
export LT_USERNAME=LT_USERNAME
export LT_ACCESS_KEY=LT_ACCESS_KEY
```

For Linux:

```bash
export LT_USERNAME=LT_USERNAME
export LT_ACCESS_KEY=LT_ACCESS_KEY
```

For Windows:

```bash
set LT_USERNAME=LT_USERNAME
set LT_ACCESS_KEY=LT_ACCESS_KEY
```

Please visit [LambdaTest Capabilities Generator](https://www.lambdatest.com/capabilities-generator/) to generate capabilities for the test cases.

## How to run tests

Once the environment variables are exported, run the following command from the terminal (after navigating to the root directory):

```bash
dotnet test LT_CSharp_Asserts.sln
```

Below is how the test execution looks on LambdaTest:

![image](https://github.com/andreea-qa/SeleniumActionsCSharp/assets/60468653/cf489133-d2f9-4b3f-b88b-ba971d065f80)


