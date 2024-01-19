import type { HttpContextContract } from '@ioc:Adonis/Core/HttpContext'
import Schema from '@ioc:Adonis/Lucid/Schema'
import Student from 'App/Models/Student'
import { schema, rules } from '@ioc:Adonis/Core/Validator'
import StudentValidator from 'App/Validators/StudentValidator'


export default class StudentsController {
  public async index({}: HttpContextContract) {
    //return {hello: 'Jesse'}
    const students = await Student.all()

    return students
  }

  public async store({request, response}: HttpContextContract) {
    
    const notValid = await Student.find(request.input("id"))
    const payload = await request.validate(StudentValidator)
    

    if(notValid){
      return response.badRequest({message: "Student already exists"})

    }
    const student: Student = await Student.create(payload)

  
    return response.ok(student)
    
    
  }

  public async show({params, response}: HttpContextContract) {
    const student = await Student.find(params.id)

    if(!student){
      return response.badRequest({message: "Student not found"})
    }

    

    return response.ok(student)
  }

  public async update({params, request, response}: HttpContextContract) {
    const id = params.id
    const student = await Student.findOrFail(id)
    if(!student){
      return response.badRequest({message: "student not found"})
    }
    if(request.method() === 'PUT'){
      const payload = await request.validate(StudentValidator)
      student.merge(payload)
    }
    
    else if(request.method() === 'PATCH'){
        //student.id = id
        student.GivenName = request.input('GivenName')
        student.LastName = request.input('LastName')
        student.EmailAddress = request.input('EmailAddress')
    }
  
    await student.save()
    return response.ok(student)

  }

  public async destroy({params, response}: HttpContextContract) {
    const id = params.id
    const student = await Student.find(id)
    if(!student){
      return response.badRequest({message: "Student not found"})
    }
    await student.delete()
    return response.ok({
      message: 'Student' + id + ':' + student.GivenName + ' was deleted successfully'
    })
  }
}
