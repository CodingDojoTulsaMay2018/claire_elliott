from __future__ import unicode_literals
from django.db import models

class CourseManager(models.Manager):
    def basic_validator(self, postData):
        errors = []
        if len(postData['course_name']) < 5:
            errors.append("Course name is too short")
        if len(postData['description']) < 15:
            errors.append("Description must be at least 15 characters")
        return errors

class Course(models.Model):
    name = models.CharField(max_length=100)
    description = models.TextField(blank=True, null=True)
    created_at = models.DateTimeField(auto_now_add=True)
    updated_at = models.DateTimeField(auto_now=True)

    objects = CourseManager()