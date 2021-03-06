# -*- coding: utf-8 -*-
# Generated by Django 1.10 on 2018-06-28 16:50
from __future__ import unicode_literals

from django.db import migrations, models
import django.db.models.deletion
import picklefield.fields


class Migration(migrations.Migration):

    initial = True

    dependencies = [
        ('login_registration', '0001_initial'),
    ]

    operations = [
        migrations.CreateModel(
            name='Campaign',
            fields=[
                ('id', models.AutoField(auto_created=True, primary_key=True, serialize=False, verbose_name='ID')),
                ('name', models.CharField(max_length=50)),
                ('desc', models.CharField(max_length=150)),
                ('members', models.ManyToManyField(related_name='has_campaigns', to='login_registration.User')),
                ('owner', models.OneToOneField(on_delete=django.db.models.deletion.CASCADE, to='login_registration.User')),
            ],
        ),
        migrations.CreateModel(
            name='Character',
            fields=[
                ('id', models.AutoField(auto_created=True, primary_key=True, serialize=False, verbose_name='ID')),
                ('name', models.CharField(max_length=75)),
                ('race', models.CharField(max_length=30)),
                ('subrace', models.CharField(blank=True, max_length=30, null=True)),
                ('char_class', models.CharField(max_length=30)),
                ('char_subclass', models.CharField(blank=True, max_length=50, null=True)),
                ('alignment', models.CharField(max_length=30)),
                ('level', models.IntegerField()),
                ('exp', models.IntegerField()),
                ('background', models.CharField(max_length=30)),
                ('age', models.IntegerField()),
                ('gender', models.CharField(max_length=20)),
                ('height', models.IntegerField(blank=True, null=True)),
                ('weight', models.IntegerField(blank=True, null=True)),
                ('stats', picklefield.fields.PickledObjectField(editable=False)),
                ('skills', picklefield.fields.PickledObjectField(editable=False)),
                ('tools', picklefield.fields.PickledObjectField(editable=False)),
                ('equipment', picklefield.fields.PickledObjectField(editable=False)),
                ('personality', models.TextField(blank=True, null=True)),
                ('desc', models.TextField(blank=True, null=True)),
                ('flaws', models.TextField(blank=True, null=True)),
                ('ideals', models.TextField(blank=True, null=True)),
                ('in_campaign', models.ForeignKey(on_delete=django.db.models.deletion.CASCADE, related_name='has_characters', to='campaigns.Campaign')),
                ('played_by', models.ForeignKey(on_delete=django.db.models.deletion.CASCADE, related_name='has_characters', to='login_registration.User')),
            ],
        ),
        migrations.CreateModel(
            name='City',
            fields=[
                ('id', models.AutoField(auto_created=True, primary_key=True, serialize=False, verbose_name='ID')),
                ('name', models.CharField(max_length=100)),
                ('desc', models.TextField()),
                ('campign', models.ForeignKey(on_delete=django.db.models.deletion.CASCADE, related_name='has_cities', to='campaigns.Campaign')),
            ],
        ),
        migrations.CreateModel(
            name='Country',
            fields=[
                ('id', models.AutoField(auto_created=True, primary_key=True, serialize=False, verbose_name='ID')),
                ('name', models.CharField(max_length=100)),
                ('desc', models.TextField()),
                ('campign', models.ForeignKey(on_delete=django.db.models.deletion.CASCADE, related_name='has_countries', to='campaigns.Campaign')),
            ],
        ),
        migrations.CreateModel(
            name='NPC',
            fields=[
                ('id', models.AutoField(auto_created=True, primary_key=True, serialize=False, verbose_name='ID')),
                ('name', models.CharField(max_length=100)),
                ('race', models.CharField(max_length=30)),
                ('subrace', models.CharField(blank=True, max_length=30, null=True)),
                ('char_class', models.CharField(max_length=30)),
                ('char_subclass', models.CharField(blank=True, max_length=50, null=True)),
                ('alignment', models.CharField(max_length=30)),
                ('level', models.IntegerField()),
                ('exp', models.IntegerField()),
                ('background', models.CharField(max_length=30)),
                ('age', models.IntegerField()),
                ('gender', models.CharField(max_length=20)),
                ('height', models.IntegerField(blank=True, null=True)),
                ('weight', models.IntegerField(blank=True, null=True)),
                ('stats', picklefield.fields.PickledObjectField(editable=False)),
                ('skills', picklefield.fields.PickledObjectField(editable=False)),
                ('tools', picklefield.fields.PickledObjectField(editable=False)),
                ('equipment', picklefield.fields.PickledObjectField(editable=False)),
                ('personality', models.TextField(blank=True, null=True)),
                ('desc', models.TextField(blank=True, null=True)),
                ('flaws', models.TextField(blank=True, null=True)),
                ('ideals', models.TextField(blank=True, null=True)),
                ('campaign', models.ForeignKey(on_delete=django.db.models.deletion.CASCADE, related_name='has_npcs', to='campaigns.Campaign')),
            ],
        ),
        migrations.AddField(
            model_name='city',
            name='country',
            field=models.ForeignKey(on_delete=django.db.models.deletion.CASCADE, related_name='has_cities', to='campaigns.Country'),
        ),
    ]
