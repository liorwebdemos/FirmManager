import { Type } from "class-transformer";
import { DepartmentModel } from "./department-model";

export enum Gender
{
  Male = 1,
  Female = 2
}

/**
 * 
 */
export class WorkerModel
{
  /**  */
  id: number;

  /**  */
  israeliIdentityNumber?: number;

  /**  */
  firstName: string;

  /**  */
  lastName: string;

  /**  */
  gender?: Gender;

  /**  */
  @Type(() => Date)
  jobStartDate?: Date;

  /**  */
  @Type(() => Date)
  jobEndDate?: Date;

  /**  */
  jobDescription: string;

  /**  */
  departmentId?: number;

  // @Type(() => DepartmentModel)
  // /**  */
  // department?: DepartmentModel;
}
