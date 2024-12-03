using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Xml.Linq;
using PT.Domain.Entities.Budget;
using Microsoft.VisualBasic;

namespace PT.Application.Abstraction.Email
{
    public class EmailTemplate
    {
        public static string GetWelcomeEmail(string lastName)
        {
            return WelcomeEmail.Replace("[User's Name]", lastName);
        }
        public static string GetBudgetCreatedEmail(string name,string amount, DateOnly startDate, DateOnly endDate)
        {
            return BudgetCreatedEmail.Replace(
               " [Budget Name]", name).Replace("[Total Amount]", amount).Replace("[Start Date]", startDate.ToString()).Replace("[End Date]", endDate.ToString());
        }
        private const string WelcomeEmail = """
     <!DOCTYPE html>
     <html lang="en">
     <head>
        <meta charset="UTF-8">
        <meta name="viewport" content="width=device-width, initial-scale=1.0">
         <title>Welcome to [App Name]</title>
          <style>
    body {
      font-family: Arial, sans-serif;
      background-color: #f4f4f4;
      margin: 0;
      padding: 0;
      color: #333;
    }
    .email-container {
      max-width: 600px;
      margin: 20px auto;
      background-color: #ffffff;
      padding: 20px;
      border-radius: 8px;
      box-shadow: 0 2px 4px rgba(0, 0, 0, 0.1);
    }
    h1 {
      color: #4CAF50;
    }
    p {
      line-height: 1.6;
    }
    .button {
      display: inline-block;
      background-color: #4CAF50;
      color: white;
      padding: 10px 20px;
      text-decoration: none;
      border-radius: 5px;
      font-weight: bold;
    }
    .button:hover {
      background-color: #45a049;
    }
    .footer {
      margin-top: 20px;
      font-size: 0.9em;
      color: #777;
    }
  </style>
</head>
<body>
  <div class="email-container">
    <h1>Welcome to [App Name] 🎉</h1>
    <p>Hi [User's Name],</p>
    <p>We're thrilled to have you on board! [App Name] is designed to help you stay on top of your goals and track your progress effortlessly.</p>
    <p>Here’s what you can do:</p>
    <ul>
      <li>✨ <strong>Track Your Progress:</strong> Stay organized with easy-to-use tracking features.</li>
      <li>📊 <strong>Visualize Your Growth:</strong> Gain insights with beautiful charts and reports.</li>
      <li>📅 <strong>Set & Achieve Goals:</strong> Stay motivated with reminders and progress milestones.</li>
    </ul>
    <p>Get started in just a few steps:</p>
    <ol>
      <li>Set up your profile.</li>
      <li>Start tracking your activities.</li>
      <li>Review and improve your progress.</li>
    </ol>
    <p>If you need any assistance, feel free to reach out to us at [Support Email].</p>
    <p><a href="[App Link]" class="button">Get Started Now</a></p>
    <p class="footer">Happy Tracking!<br>The [App Name] Team</p>
  </div>
</body>
</html>
""";

        private const string BudgetCreatedEmail =
            """
<!DOCTYPE html>
<html lang="en">
<head>
  <meta charset="UTF-8">
  <meta name="viewport" content="width=device-width, initial-scale=1.0">
  <title>Budget Created Successfully!</title>
  <style>
    body {
      font-family: Arial, sans-serif;
      background-color: #f4f4f4;
      margin: 0;
      padding: 0;
      color: #333;
    }
    .email-container {
      max-width: 600px;
      margin: 20px auto;
      background-color: #ffffff;
      padding: 20px;
      border-radius: 8px;
      box-shadow: 0 2px 4px rgba(0, 0, 0, 0.1);
    }
    h1 {
      color: #4CAF50;
    }
    p {
      line-height: 1.6;
    }
    .button {
      display: inline-block;
      background-color: #4CAF50;
      color: white;
      padding: 10px 20px;
      text-decoration: none;
      border-radius: 5px;
      font-weight: bold;
    }
    .button:hover {
      background-color: #45a049;
    }
    .footer {
      margin-top: 20px;
      font-size: 0.9em;
      color: #777;
    }
  </style>
</head>
<body>
  <div class="email-container">
    <h1>🎉 Your Budget is Ready!</h1>
    <p>Hi [User's Name],</p>
    <p>Great news! You've successfully created a new budget in [App Name]. Here’s a quick summary:</p>
    <ul>
      <li><strong>Budget Name:</strong> [Budget Name]</li>
      <li><strong>Total Amount:</strong> [Total Amount]</li>
      <li><strong>Start Date:</strong> [Start Date]</li>
      <li><strong>End Date:</strong> [End Date]</li>
    </ul>
    <p>Tracking your expenses and staying within budget is now easier than ever. Use the app to monitor your spending, adjust your categories, and stay on track toward your financial goals.</p>
    <p><a href="[App Link]" class="button">View My Budget</a></p>
    <p>If you need any assistance or have questions, feel free to reach out to our support team at [Support Email].</p>
    <p class="footer">Happy Budgeting!<br>The [App Name] Team</p>
  </div>
</body>
</html>
""";
    }
}
