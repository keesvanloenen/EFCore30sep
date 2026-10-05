using BenchmarkDotNet.Attributes;
using Microsoft.EntityFrameworkCore;
using School.Library.DAL;
using School.Library.Models;

namespace School.Benchmark;

[MemoryDiagnoser]
public class EFCoreBenchmarks
{
    private SchoolContext _context = null!;

    [GlobalSetup]
    public void Setup()
    {
        _context = new SchoolContext();
        _context.Database.EnsureCreated();
    }

    [GlobalCleanup]
    public void Cleanup()
    {
        _context.Dispose();
    }

    [Benchmark]
    public List<Person> LoadAllPeople_Tracking()
    {
        return _context.People.ToList();
    }

    [Benchmark]
    public List<Person> LoadAllPeople_NoTracking()
    {
        return _context.People.AsNoTracking().ToList();
    }

    [Benchmark]
    public List<string> ProjectBlogUrls()
    {
        return _context.People.Select(p => p.FirstName).ToList();
    }
}