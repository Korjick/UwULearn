using System;
using System.Collections.Generic;

public class ReceivedData
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class Cat
    {
        public string name { get; set; }
        public int health { get; set; }
        public Skin skin { get; set; }
    }

    public class Course
    {
        public string name { get; set; }
        public string description { get; set; }
        public List<Lesson> lessons { get; set; }
    }

    public class From
    {
        public string username { get; set; }
        public DateTime registrationDate { get; set; }
        public DateTime updateDate { get; set; }
        public Cat cat { get; set; }
        public List<Course> courses { get; set; }
        public List<string> friendList { get; set; }
        public int energy { get; set; }
    }

    public class Lesson
    {
        public string name { get; set; }
        public string description { get; set; }
        public string text { get; set; }
        public string video { get; set; }
        public Task task { get; set; }
    }

    public class Root
    {
        public From from { get; set; }
        public DateTime date { get; set; }
        public string text { get; set; }
    }

    public class Skin
    {
        public string name { get; set; }
        public string skinUrl { get; set; }
    }

    public class Task
    {
        public string descriotion { get; set; }
        public string example { get; set; }
        public string correctAnswer { get; set; }
        public int reward { get; set; }
    }
}