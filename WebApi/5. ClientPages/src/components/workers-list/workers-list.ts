import { AddWorkerModal } from "./../add-worker-modal/add-worker-modal";
import { autoinject } from "aurelia-framework";
import { WorkerModel } from "models";
import { DialogService } from "aurelia-dialog";
import { WorkerDetailsModal } from "components/worker-details-modal/worker-details-modal";
import { WorkersService } from "services";
import { handleErrors } from "decorators";

@autoinject()
export class WorkersList
{
  private workers: WorkerModel[];

  constructor(
    private workersService: WorkersService,
    private dialogService: DialogService
  ) { }

  private activate(): void
  {
    this.getWorkers();
  }

  @handleErrors("An error occurred while retrieving the workers.")
  private getWorkers(): Promise<WorkerModel[]>
  {
    return this.workersService.getWorkers()
      .then(workers => this.workers = workers.sort(WorkersList.sortWorkersByFirstNameAscending));
  }

  private openWorkerDetailsModal(worker: WorkerModel): void
  {
    this.dialogService.open({
      viewModel: WorkerDetailsModal,
      model: worker
    })
      .whenClosed(response =>
      {
        if (response.wasCancelled) return;
        this.workers = this.workers
          .map(
            d => d.id === worker.id
              ? response.output
              : d)
          .sort(WorkersList.sortWorkersByFirstNameAscending);
      });
  }

  private openAddWorkerModal(): void
  {
    this.dialogService.open({
      viewModel: AddWorkerModal
    })
      .whenClosed(response =>
      {
        if (response.wasCancelled) return;
        this.workers.push(response.output);
        return this.workers.sort(WorkersList.sortWorkersByFirstNameAscending);
      });
  }

  private static sortWorkersByFirstNameAscending = (a: WorkerModel, b: WorkerModel) => a.firstName?.localeCompare(b.firstName);
}
