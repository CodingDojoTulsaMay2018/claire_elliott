from __future__ import unicode_literals
from django.db import models
from picklefield.fields import PickledObjectField
from ..login_registration.models import User

class Campaign(models.Model):
    name = models.CharField(max_length=50)
    desc = models.CharField(max_length=150)
    owner = models.OneToOneField(User, on_delete=models.CASCADE)
    members = models.ManyToManyField(User, related_name="has_campaigns")

class Spell(models.Model):
    name = models.CharField(max_length=255)
    spell_type = models.CharField(max_length=30)
    cast_time = models.IntegerField()
    cast_range = models.IntegerField()
    components = PickledObjectField()
    duration = models.IntegerField()
    desc = models.TextField()

class Feat(models.Model):
    name = models.CharField(max_length=255)
    desc = models.TextField()
    bonus = PickledObjectField()

class Character(models.Model):
    played_by = models.ForeignKey(User, on_delete=models.CASCADE, related_name="has_characters")
    in_campaign = models.ForeignKey(Campaign, on_delete=models.CASCADE, related_name="has_characters")
    name = models.CharField(max_length=75)
    race = models.CharField(max_length=30)
    subrace = models.CharField(max_length=30,blank=True,null=True)
    char_class = models.CharField(max_length=30)
    char_subclass = models.CharField(max_length=50,blank=True,null=True)
    alignment = models.CharField(max_length=30)
    level = models.IntegerField()
    exp = models.IntegerField()
    background = models.CharField(max_length=30)
    age = models.IntegerField()
    gender = models.CharField(max_length=20)
    height = models.IntegerField(blank=True,null=True)
    weight = models.IntegerField(blank=True,null=True)
    stats = PickledObjectField()
    skills = PickledObjectField()
    tools = PickledObjectField()
    has_spells = models.ManyToManyField(Spell, related_name="used_by")
    has_feats = models.ManyToManyField(Feat, related_name="used_by")
    equipment = PickledObjectField()
    personality = models.TextField(blank=True,null=True)
    desc = models.TextField(blank=True,null=True)
    flaws = models.TextField(blank=True,null=True)
    ideals = models.TextField(blank=True,null=True)